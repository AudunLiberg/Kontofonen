using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Kontofonen.Domain.Auth;
using Kontofonen.Web.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Kontofonen.Web.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ApiConfig _apiConfig;

        public AuthController(IOptions<ApiConfig> apiConfig)
        {
            _apiConfig = apiConfig.Value;
        }

        [HttpGet]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (_apiConfig.IsProduction)
            {
                var url = AuthHelpers.GetSpareBank1AuthorizeUrl(_apiConfig.ClientId, _apiConfig.RedirectUri, returnUrl);
                return Redirect(url);
            }

            RequestDevelopmentToken();
            return Redirect(returnUrl);
        }

        [HttpGet]
        [Route("logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult RequestProductionToken(string code, string state)
        {
            var parameters = new Dictionary<string, object>
            {
                { "grant_type", "authorization_code" },
                { "redirect_uri", _apiConfig.RedirectUri },
                { "code", code },
                { "state", state }
            };
            
            RequestTokenAndSignIn(parameters);

            return Redirect(state);
        }

        private void RequestDevelopmentToken()
        {
            var parameters = new Dictionary<string, object>
            {
                { "grant_type", "client_credentials" }
            };

            RequestTokenAndSignIn(parameters);
        }

        private void RequestTokenAndSignIn(IDictionary<string, object> parameters)
        {
            parameters.Add("client_id", _apiConfig.ClientId);
            parameters.Add("client_secret", _apiConfig.ClientSecret);

            var client = new RestClient(_apiConfig.BaseUrl + "oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", AuthHelpers.CreateQueryString(parameters), ParameterType.RequestBody);
            var response = client.Execute(request);
            var oAuthToken = JsonSerializer.Deserialize<OAuthTokenResponse>(response.Content);

            SignIn(oAuthToken.access_token);
        }

        private async void SignIn(string token)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Authentication, token)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
        }
    }
}
