namespace WallboxApi.Models.ChargerConfig;

public class ChargerConfigResume
{
    public int totalUsers { get; set; }
    public int totalSessions { get; set; }
    public string chargingTime { get; set; }
    public string totalEnergy { get; set; }
    public string totalMidEnergy { get; set; }
    public string energyUnit { get; set; }
}