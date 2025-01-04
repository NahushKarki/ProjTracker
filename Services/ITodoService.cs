using System.Collections.Generic;
using System.Threading.Tasks;
using Tracker.Models;

namespace Tracker.Services
{
    public interface ITodoService
    {

        Task AddTaskAsync(TodoTask task);

        
        Task<List<TodoTask>> GetTasksByUserIdAsync(int userId);
    }
}
