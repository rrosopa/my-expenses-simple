namespace Core.Models.Configurations
{
    public class AppSettings
    {
        public string AppDbConnectionString { get; set; }
        public string AppGrantType { get; set; }

        public Jwt Jwt { get; set; }

        public string[] AllowedOrigins { get; set; }
    }
}
