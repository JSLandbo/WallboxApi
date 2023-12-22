namespace WallboxApi.Models.PreviousChargingSession;

public class PreviousChargerSessionAttributes
{
    public string id { get; set; }
    public int start_time { get; set; }
    public int end_time { get; set; }
    public int charging_time { get; set; }
    public int user_id { get; set; }
    public string user_name { get; set; }
    public string user_surname { get; set; }
    public string user_email { get; set; }
    public int charger_id { get; set; }
    public string charger_name { get; set; }
    public int group_id { get; set; }
    public int location_id { get; set; }
    public string location_name { get; set; }
    public int energy { get; set; }
    public int mid_energy { get; set; }
    public float energy_price { get; set; }
    public string currency_code { get; set; }
    public string session_type { get; set; }
    public int application_fee_percentage { get; set; }
    public string user_avatar { get; set; }
    public object order_uid { get; set; }
    public object rate_price { get; set; }
    public object rate_variable_type { get; set; }
    public object order_energy { get; set; }
    public object access_price { get; set; }
    public object fee_amount { get; set; }
    public object total { get; set; }
    public object subtotal { get; set; }
    public object tax_amount { get; set; }
    public object tax_percentage { get; set; }
    public float total_cost { get; set; }
    public object public_charge_uid { get; set; }
}