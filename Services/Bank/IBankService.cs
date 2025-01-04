using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Models;

namespace Tracker.Services.Bank
{
    public interface IBankService
    {
        Task AddBankAsync(BankAccount bank);


        Task<List<BankAccount>> GetBanksByUserIdAsync(int userId);
    }
}
