using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WallboxApi.Models;
using WallboxApi.Models.ChargerInformationModel;
using WallboxApi.Requests;

namespace WallboxApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WallboxController : ControllerBase
    {
        private readonly ILogger<WallboxController> _logger;
        private IWallboxRequestManager _wallboxManager;

        public WallboxController(ILogger<WallboxController> logger, IWallboxRequestManager wallboxManager)
        {
            _logger = logger;
            _wallboxManager = wallboxManager;
        }

        [HttpGet("GetWallboxInformation")]
        public async Task<ChargerInformationModel> GetWallboxInformation()
        {
            var getChargerConfig = await _wallboxManager.GetChargerConfig();
            var getChargerStatus = await _wallboxManager.GetChargerStatus();
            var getLatestSession = await _wallboxManager.GetLatestChargingSession();

            bool isCharging = getChargerConfig.GetStatus().Equals(194);
            var chargingPower = getChargerStatus.GetChargingPower();
            var latestSession = getLatestSession.GetLatestSessionInformation();

            var sessionInfoMqtt = new ChargerSessionInformation()
            {
                StartDate = EpochToDate(latestSession.start_time).AddHours(2),
                EndDate = null,
                DurationSeconds = null,
                Charged = latestSession.charging_energy * 1000.0f,
                ChargeSpeed = chargingPower * 1000.0f,
                TotalCost = null,
                ChargeUnit = "Wh",
                Valuta = "DKK"
            };

            var getPreviousSession = await _wallboxManager.GetPreviousChargingSession();
            var previousSession = getPreviousSession.GetPreviousChargingSessionInformation();
            var lastSessionMqtt = new ChargerSessionInformation()
            {
                Charged = previousSession.energy,
                ChargeSpeed = null,
                StartDate = EpochToDate(previousSession.start_time).AddHours(2),
                EndDate = EpochToDate(previousSession.end_time).AddHours(2),
                DurationSeconds = previousSession.charging_time,
                TotalCost = null,
                ChargeUnit = "Wh",
                Valuta = "DKK"
            };

            return new ChargerInformationModel()
            {
                Charging = isCharging,
                SessionInfo = isCharging ? sessionInfoMqtt : null,
                LastSessionInfo = lastSessionMqtt
            };
        }

        [HttpPost("SetWallboxChargeState/{state}")]
        public async Task<ObjectResult> SetWallboxChargeState(string state)
        {
            Enum.TryParse(state.ToUpper(), out WallboxChargeState chargeState);
            _logger.LogInformation(JsonConvert.SerializeObject(
                await _wallboxManager.SetChargerChargeState(chargeState), 
                Formatting.Indented
            ));
            return new OkObjectResult($"Wallbox {state} request sent.");
        }

        [HttpPost("SetWallboxCurrent/{amp}")]
        public async Task<ObjectResult> SetWallboxCurrent(int amp)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(
                await _wallboxManager.SetMaxChargingCurrent(amp > 16 ? 16 : amp),
                Formatting.Indented
            ));
            return new OkObjectResult($"Charger set to {amp} amps.");
        }

        [HttpPost("SetWallboxAvailability/{state}")]
        public async Task<ObjectResult> SetWallboxAvailability(string state)
        {
            _ = Enum.TryParse(state.ToUpper(), out WallboxLockState lockState);
            _logger.LogInformation(JsonConvert.SerializeObject(
                await _wallboxManager.SetChargerLockState(lockState),
                Formatting.Indented
            ));
            return new OkObjectResult($"Wallbox set to {state}");
        }

        private static DateTime EpochToDate(int epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(epoch);
        }
    }
}