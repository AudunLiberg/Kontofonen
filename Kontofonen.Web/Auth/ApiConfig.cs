using System;

namespace Kontofonen.Web.Auth
{
    public class ApiConfig
    {
        public string BaseUrl { get; set; }
        public Guid ClientId { get; set; }
        public Guid ClientSecret { get; set; }
        public bool IsProduction { get; set; }
        public string RedirectUri { get; set; }
    }
}
