using bARTapp.Dtos;
using bARTapp.Models;

namespace bARTapp.Services.Interfaces
{
    public interface IAccountService
    {
        Task CreateAccountAsync(Account account);

        Task UpdateAccountAsync(Account account);

        Task<Account> GetAccountByNameAsync(string name);

        List<Account> GetAllAccounts();
    }
}
