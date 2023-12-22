using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WallboxApi.Models;
using WallboxApi.Models.Options;

namespace WallboxApi.Auth;

public class WallboxTokenManager : IWallboxTokenManager
{
    private readonly string _username;
    private readonly string _password;

    public WallboxTokenManager(IWallboxOptions options)
    {
        _username = options.Username;
        _password = options.Password;
    }

    private WallboxToken token;
    public WallboxToken Token
    {
        get
        {
            return token ??= GetAuthToken().GetAwaiter().GetResult();
        }
    }

    private async Task<WallboxToken?> GetAuthToken()
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, "auth/token/user");

        requestMessage.Headers.Authorization = GetBasicAuth(_username, _password);

        requestMessage.Headers.Add("Accept", "application/json, text/plain, */*");

        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://api.wall-box.com/")
        };

        var response = await httpClient.SendAsync(requestMessage);

        return JsonConvert.DeserializeObject<WallboxToken>(await response.Content.ReadAsStringAsync());
    }

    private static AuthenticationHeaderValue GetBasicAuth(string username, string password)
    {
        return new AuthenticationHeaderValue(
            "Basic",
            Convert.ToBase64String(
                Encoding.ASCII.GetBytes($"{username}:{password}")
            )
        );
    }
}