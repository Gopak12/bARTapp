using bARTapp.Data;
using bARTapp.Dtos;
using bARTapp.Models;
using bARTapp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bARTapp.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;

        public AccountService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAccountAsync(Account account)
        {
            await _context.Account.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account> GetAccountByNameAsync(string name)
        {
            return _context.Account.FirstOrDefault(x => x.Name == name);
        }

        public List<Account> GetAllAccounts()
        {
            return _context.Account.Include(a => a.Contacts).ToList();
        }
    }
}
