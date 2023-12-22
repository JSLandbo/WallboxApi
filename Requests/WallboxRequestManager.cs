using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using WallboxApi.Auth;
using WallboxApi.Models;
using WallboxApi.Models.ActiveChargerSession;
using WallboxApi.Models.ChargerConfig;
using WallboxApi.Models.ChargerStatus;
using WallboxApi.Models.Options;
using WallboxApi.Models.PreviousChargingSession;

namespace WallboxApi.Requests;

public class WallboxRequestManager : IWallboxRequestManager
{
    private IWallboxTokenManager TokenManager { get; set; }
    private readonly HttpClient _httpClient;
    private readonly int _chargerId;
    private readonly int _groupId;

    public WallboxRequestManager(IWallboxTokenManager tokenManager, IWallboxOptions options, HttpClient httpClient)
    {
        this.TokenManager = tokenManager;
        this._httpClient = httpClient;
        this._chargerId = options.ChargerId;
        this._groupId = options.GroupId;
    }

    public async Task<JObject> GetChargersList()
    {
        return await InternalRequest<JObject>(
            type: HttpMethod.Get,
            path: "v3/chargers/groups"
        );
    }

    public async Task<ChargerStatus> GetChargerStatus()
    {
        return await InternalRequest<ChargerStatus>(
            type: HttpMethod.Get,
            path: $"chargers/status/{_chargerId}"
        );
    }

    public async Task<ChargerConfig> GetChargerConfig()
    {
        return await InternalRequest<ChargerConfig>(
            type: HttpMethod.Get,
            path: $"v2/charger/{_chargerId}"
        );
    }

    public async Task<JObject> SetMaxChargingCurrent(int newMaxCurrent)
    {
        return await InternalRequest<JObject>(
            type: HttpMethod.Put,
            path: $"v2/charger/{_chargerId}",
            json: JsonContent.Create(new { maxChargingCurrent = newMaxCurrent })
        );
    }


    public async Task<JObject> SetChargerLockState(WallboxLockState state)
    {
        return await InternalRequest<JObject>(
            type: HttpMethod.Put,
            path: $"v2/charger/{_chargerId}",
            json: JsonContent.Create(new { locked = state })
        );
    }

    public async Task<JObject> SetChargerChargeState(WallboxChargeState state)
    {
        return await InternalRequest<JObject>(
            type: HttpMethod.Post,
            path: $"v3/chargers/{_chargerId}/remote-action",
            json: JsonContent.Create(new { action = state })
        );
    }

    public async Task<JObject> GetGroupsForUser()
    {
        return await InternalRequest<JObject>(
            type: HttpMethod.Get,
            path: $"v3/users/groups"
        );
    }

    public async Task<ActiveChargerSession> GetLatestChargingSession()
    {
        return await InternalRequest<ActiveChargerSession>(
            type: HttpMethod.Get,
            path: $"v4/charger-last-sessions?limit=1"
        );
    }

    public async Task<PreviousChargerSession> GetPreviousChargingSession(int limit = 1, int offset = 0)
    {
        return await InternalRequest<PreviousChargerSession>(
            type: HttpMethod.Get,
            path: $"v4/groups/{_groupId}/charger-charging-sessions?limit={limit}&offset={offset}"
        );
    }

    private async Task<T> InternalRequest<T>(HttpMethod type, string path, JsonContent? json = null)
    {
        var requestMessage = new HttpRequestMessage(type, path);

        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.Token.Jwt);

        requestMessage.Content = json;

        var response = await _httpClient.SendAsync(requestMessage);

        var content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<T>(content)!;
    }
}