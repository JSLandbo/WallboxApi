namespace WallboxApi.Models.ChargerStatus;

public class ChargerStatusSoftware
{
    public bool updateAvailable { get; set; }
    public string currentVersion { get; set; }
    public string latestVersion { get; set; }
    public string fileName { get; set; }
}