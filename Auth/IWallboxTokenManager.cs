using WallboxApi.Models;

namespace WallboxApi.Auth
{
    public interface IWallboxTokenManager
    {
        WallboxToken Token { get; }
    }
}