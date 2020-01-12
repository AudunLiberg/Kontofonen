namespace Kontofonen.Domain.Auth
{
    public class OAuthTokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public string state { get; set; }
        public string userinfo { get; set; }
        public string financial_institution_id { get; set; }
    }
}
