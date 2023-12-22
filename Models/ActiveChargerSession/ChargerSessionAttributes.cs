namespace WallboxApi.Models.ActiveChargerSession;

public class ChargerSessionAttributes
{
    public int charger_id { get; set; }
    public int user_id { get; set; }
    public float charging_energy { get; set; }
    public string charging_energy_unit { get; set; }
    public int charging_green_energy { get; set; }
    public string charging_green_energy_unit { get; set; }
    public int discharged_energy { get; set; }
    public string discharged_energy_unit { get; set; }
    public int start_time { get; set; }
    public int end_time { get; set; }
}