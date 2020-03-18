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

        [HttpGet("{accountId}")]
        public Account Get(string accountId)
        {
            var account = _api.Get<Account>($"open/personal/banking/accounts/{accountId}");
            return account;
        }

        [HttpGet("{accountId}/transactions")]
        public Transactions GetTransactions(string accountId)
        {
            var transactions = _api.Get<Transactions>($"open/personal/banking/accounts/{accountId}/transactions");
            return transactions;
        }
    }
}
