using BanqueITINOV.Entities;

namespace BanqueITINOV.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> SaveAllAsync();
        Task<Account> UpdateAaccountAsync(int customerId, double amount, string type);
        Task<IEnumerable<Transaction>> GetHistoricalTransactionsAsync(int customerId);

    }
}
