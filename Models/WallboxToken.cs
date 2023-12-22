namespace WallboxApi.Models;

public class WallboxToken
{
    public string Jwt { get; set; }
    public int User_id { get; set; }
    public int Ttl { get; set; }
    public bool Error { get; set; }
    public int Status { get; set; }
}