namespace WallboxApi.Models.ActiveChargerSession;

public class ChargerSessionDatum
{
    public string type { get; set; }
    public string id { get; set; }
    public ChargerSessionAttributes attributes { get; set; }
}