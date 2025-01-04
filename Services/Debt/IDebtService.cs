using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Models;

namespace Tracker.Services.Debt
{
    public interface IDebtService
    {
        Task AddDebtAsync(TotalDebt debt);


        Task<List<TotalDebt>> GetDebtsByUserIdAsync(int userId);
    }
}
