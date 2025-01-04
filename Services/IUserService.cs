using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Models;

namespace Tracker.Services
{
    public interface IUserService
    {
        Task SaveUserAsync(User user);
        
        Task<List<User>> LoadUsersAsync();
    }
}
