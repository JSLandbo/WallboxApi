using Newtonsoft.Json.Linq;
using WallboxApi.Models;
using WallboxApi.Models.ActiveChargerSession;
using WallboxApi.Models.ChargerConfig;
using WallboxApi.Models.ChargerStatus;
using WallboxApi.Models.PreviousChargingSession;

namespace WallboxApi.Requests
{
    public interface IWallboxRequestManager
    {
        Task<ChargerConfig> GetChargerConfig();
        Task<JObject> GetChargersList();
        Task<ChargerStatus> GetChargerStatus();
        Task<JObject> GetGroupsForUser();
        Task<ActiveChargerSession> GetLatestChargingSession();
        Task<PreviousChargerSession> GetPreviousChargingSession(int limit = 1, int offset = 0);
        Task<JObject> SetChargerChargeState(WallboxChargeState state);
        Task<JObject> SetChargerLockState(WallboxLockState state);
        Task<JObject> SetMaxChargingCurrent(int newMaxCurrent);
    }
}