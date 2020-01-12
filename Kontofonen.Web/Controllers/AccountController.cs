using Kontofonen.Domain.Account;
using Kontofonen.Web.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Kontofonen.Web.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly ApiProxy _api;

        public AccountController(ApiProxy api)
        {
            _api = api;
        }

        [HttpGet]
        public Accounts GetAll()
        {
            var accounts = _api.Get<Accounts>("open/personal/banking/accounts/all");
            return accounts;
        }
    }
}
