namespace WallboxApi.Models.ChargerConfig;

public class ChargerConfigChargerdata
{
    public int id { get; set; }
    public string uid { get; set; }
    public string serialNumber { get; set; }
    public string name { get; set; }
    public int group { get; set; }
    public string groupUid { get; set; }
    public string chargerType { get; set; }
    public string softwareVersion { get; set; }
    public int status { get; set; }
    public int ocppConnectionStatus { get; set; }
    public string ocppReady { get; set; }
    public object stateOfCharge { get; set; }
    public int maxChgCurrent { get; set; }
    public int maxAvailableCurrent { get; set; }
    public int maxChargingCurrent { get; set; }
    public int locked { get; set; }
    public int lastConnection { get; set; }
    public ChargerConfigLastsync lastSync { get; set; }
    public int midEnabled { get; set; }
    public int midMargin { get; set; }
    public int midMarginUnit { get; set; }
    public string midSerialNumber { get; set; }
    public int midStatus { get; set; }
    public int wifiSignal { get; set; }
    public string connectionType { get; set; }
    public string chargerLoadName { get; set; }
    public int chargerLoadId { get; set; }
    public string chargingType { get; set; }
    public string connectorType { get; set; }
    public string protocolCommunication { get; set; }
    public string accessType { get; set; }
    public int powerSharingStatus { get; set; }
    public ChargerConfigResume resume { get; set; }
}