namespace BanqueITINOV.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public double Currency { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastModification { get; set; } = DateTime.UtcNow;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
