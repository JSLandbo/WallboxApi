namespace WallboxApi.Models.PreviousChargingSession;

public class PreviousChargerSession
{
    public PreviousChargingSessionMeta meta { get; set; }
    public PreviousChargingSessionLinks links { get; set; }
    public PreviousChargingSessionDatum[] data { get; set; }

    public PreviousChargerSessionAttributes GetPreviousChargingSessionInformation()
    {
        return data.OrderByDescending(x => x.id).First().attributes;
    }
}