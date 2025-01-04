using System.Collections.Generic;
using System.Threading.Tasks;
using Tracker.Models;

namespace Tracker.Services.Transaction
{
    public interface ITransactionService
    {

        Task AddTransactionAsync(AccountTransaction transaction);


        Task<List<AccountTransaction>> GetTransactionsByUserIdAsync(int userId);


    }
}
