using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Kontofonen.Web.Auth
{
    public class ApiProxy
    {
        private readonly ApiConfig _apiConfig;
        private readonly HttpContext _httpContext;

        public ApiProxy(IOptions<ApiConfig> apiConfig, IHttpContextAccessor httpContextAccessor)
        {
            _apiConfig = apiConfig.Value;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public T Get<T>(string url)
        {
            var client = new RestClient(_apiConfig.BaseUrl + url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", $"Bearer {GetToken()}");
            request.AddHeader("Accept", "application/vnd.sparebank1.v1+json; charset=utf-8");
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var content = JsonSerializer.Deserialize<T>(response.Content);
            return content;
        }

        private string GetToken()
        {
            return _httpContext.User.Claims.Single(c => c.Type == ClaimTypes.Authentication).Value;
        }
    }
}
