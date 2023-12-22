namespace WallboxApi.Models.ChargerStatus;

public class ChargerStatus
{
    public int user_id { get; set; }
    public string user_name { get; set; }
    public int car_id { get; set; }
    public string car_plate { get; set; }
    public float depot_price { get; set; }
    public string last_sync { get; set; }
    public int power_sharing_status { get; set; }
    public int mid_status { get; set; }
    public int status_id { get; set; }
    public string name { get; set; }
    public float charging_power { get; set; }
    public int max_available_power { get; set; }
    public string depot_name { get; set; }
    public int charging_speed { get; set; }
    public int added_range { get; set; }
    public float added_energy { get; set; }
    public int added_green_energy { get; set; }
    public int added_discharged_energy { get; set; }
    public int charging_time { get; set; }
    public bool finished { get; set; }
    public int cost { get; set; }
    public int current_mode { get; set; }
    public bool preventive_discharge { get; set; }
    public object state_of_charge { get; set; }
    public int ocpp_status { get; set; }
    public ChargerStatusConfigData config_data { get; set; }

    public float GetChargingPower()
    {
        return charging_power;
    }
}