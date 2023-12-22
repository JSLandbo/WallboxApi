namespace WallboxApi.Models.ChargerConfig;

public class ChargerConfigUser
{
    public int id { get; set; }
    public object avatar { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public string email { get; set; }
    public string profile { get; set; }
    public bool assigned { get; set; }
    public bool createdByUser { get; set; }
}