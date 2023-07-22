namespace SupportPageApi.Models
{
    public class TokenSetting
    {
        public string Key { get; set; } = null!;

        public string Issuer { get; set; } = null!;

        public string Audience { get; set; } = null!;
    }
}
