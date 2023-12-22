namespace WallboxApi.Models.PreviousChargingSession;

public class PreviousChargingSessionDatum
{
    public string type { get; set; }
    public string id { get; set; }
    public PreviousChargerSessionAttributes attributes { get; set; }
}