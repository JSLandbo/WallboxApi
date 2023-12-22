namespace WallboxApi.Models.ChargerInformationModel;

public class ChargerSessionInformation
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? DurationSeconds { get; set; }
    public float? Charged { get; set; }
    public float? ChargeSpeed { get; set; }
    public string ChargeUnit { get; set; }
    public float? TotalCost { get; set; }
    public string Valuta { get; set; }
}