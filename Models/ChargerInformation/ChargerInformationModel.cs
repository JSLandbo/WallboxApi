namespace WallboxApi.Models.ChargerInformationModel;

public class ChargerInformationModel
{
    public bool Charging { get; set; }
    public ChargerSessionInformation SessionInfo { get; set; }
    public ChargerSessionInformation LastSessionInfo { get; set; }
}
