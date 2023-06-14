using BanqueITINOV.Data;
using BanqueITINOV.Entities;
using BanqueITINOV.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BanqueITINOV.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public async Task<Account> UpdateAaccountAsync(int customerId, double amount, string type)
        {
            var customer =await  _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            var account = await _context.Accounts.FirstOrDefaultAsync(u => u.Id == customerId);
            if(account != null && customer != null)
            {
                account.Currency += amount;
                account.LastModification = DateTime.UtcNow;
                
                Transaction transaction = new Transaction
                {
                    CustomerId = customerId,
                    AccountId = account.Id,
                    Amount = amount,
                    Type= type,
                    Currency = account.Currency
                };
                await _context.Transactions.AddAsync(transaction);
            }


            return account;
        }

        public async Task<IEnumerable<Transaction>> GetHistoricalTransactionsAsync(int customerId)
        {
            return await _context.Transactions.Where(u => u.Id == customerId).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
