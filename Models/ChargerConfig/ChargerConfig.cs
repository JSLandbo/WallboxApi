namespace WallboxApi.Models.ChargerConfig;

public class ChargerConfig
{
    public ChargerConfigData data { get; set; }

    internal int GetStatus()
    {
        return data.chargerData.status;
    }
}