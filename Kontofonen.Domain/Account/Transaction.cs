using System;

namespace Kontofonen.Domain.Account
{
    public class Transaction
    {
        public Money amount { get; set; }
        public DateTime accountingDate { get; set; }
        public string description { get; set; }
        public string fullDescription { get; set; }
        public string archiveReference { get; set; }
        public string remoteAccount { get; set; }
        public string transactionCode { get; set; }
        public string transactionType { get; set; }
    }
}
