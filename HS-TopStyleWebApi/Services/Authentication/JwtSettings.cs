namespace HS_TopStyleWebApi.Services.Authentication
{
    public class JwtSettings
    {
        public const string SectionName = "Authentication";

        public string SecretKey { get; set; } = null!;

        public int ExpiryInMinutes { get; set; }

        public string Issuer { get; set; } = null!;

        public string Audience { get; set; } = null!;
    }
}
