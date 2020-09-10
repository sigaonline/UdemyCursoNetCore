namespace UdemyCurso.Security.Configuration
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int seconds { get; set; }
    }
}
