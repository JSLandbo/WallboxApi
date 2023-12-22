namespace WallboxApi.Models.Options
{
    public class WallboxOptions : IWallboxOptions
    {
        public string WallboxUri { get; set; }
        public string Category { get; set; }
        public string Zone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Timeout { get; set; }
        public int ChargerId { get; set; }
        public int GroupId { get; set; }
    }
}
