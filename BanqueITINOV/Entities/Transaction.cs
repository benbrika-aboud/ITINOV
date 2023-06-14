namespace BanqueITINOV.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Type { get; set; }
        public double Currency { get; set; }
    }
}
