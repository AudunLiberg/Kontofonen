namespace Kontofonen.Domain.Account
{
    public class Account
    {
        public string id { get; set; }
        public string name { get; set; }
        public Money balance { get; set; }
        public double interestRate { get; set; }
    }
}
