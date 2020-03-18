using System.Collections.Generic;

namespace Kontofonen.Domain.Account
{
    public class Transactions
    {
        public IEnumerable<Transaction> transactions { get; set; }
    }
}
