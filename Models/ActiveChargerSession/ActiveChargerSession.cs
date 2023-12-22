namespace WallboxApi.Models.ActiveChargerSession;

public class ActiveChargerSession
{
    public ChargerSessionDatum[] data { get; set; }

    public ChargerSessionAttributes GetLatestSessionInformation()
    {
        return data.OrderByDescending(x => x.id).First()?.attributes;
    }
}