namespace WallboxApi.Models.Options
{
    public interface IWallboxOptions
    {
        string Category { get; set; }
        string Password { get; set; }
        string Username { get; set; }
        string WallboxUri { get; set; }
        string Zone { get; set; }
        public int ChargerId { get; set; }
        public int GroupId { get; set; }
    }
}