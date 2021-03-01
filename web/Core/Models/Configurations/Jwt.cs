namespace Core.Models.Configurations
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpirationInMinutes { get; set; }
    }
}
