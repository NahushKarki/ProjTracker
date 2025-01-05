using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Tracker.Models;

namespace Tracker.Services.Debt
{
    public class DebtService : IDebtService
    {
        private readonly string debtsFilePath = Path.Combine(AppContext.BaseDirectory, "DebtDetails.json");

        public async Task AddDebtAsync(TotalDebt debt)
        {
            try
            {
                var debts = await LoadDebtsAsync();
                debt.DebtId = debts.Count > 0 ? debts.Max(d => d.DebtId) + 1 : 1;
                debts.Add(debt);
                await SaveDebtsAsync(debts);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"Error adding task: {ex.Message}");
                throw; // Rethrow or handle as needed
            }
        }

        public async Task<List<TotalDebt>> GetDebtsByUserIdAsync(int userId)
        {
            try
            {
                var debts = await LoadDebtsAsync();
                // Return tasks filtered by userId or an empty list if tasks is null
                return (debts ?? new List<TotalDebt>()).Where(d => d.UserId == userId).ToList();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error retrieving tasks for user {userId}: {ex.Message}");
                return new List<TotalDebt>(); // Return an empty list in case of an exception
            }
        }

        private async Task<List<TotalDebt>> LoadDebtsAsync()
        {
            try
            {
                if (!File.Exists(debtsFilePath))
                {
                    // If the file does not exist, create it with an empty list
                    var emptyList = new List<TotalDebt>();
                    await SaveDebtsAsync(emptyList);
                    return emptyList;
                }

                var json = await File.ReadAllTextAsync(debtsFilePath);
                return JsonSerializer.Deserialize<List<TotalDebt>>(json) ?? new List<TotalDebt>();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error loading tasks: {ex.Message}");
                throw; // Rethrow or handle as needed
            }
        }


        private async Task SaveDebtsAsync(List<TotalDebt> debts)
        {
            try
            {
                var json = JsonSerializer.Serialize(debts, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(debtsFilePath, json);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error saving tasks: {ex.Message}");
                throw; // Rethrow or handle as needed
            }
        }
    }
}
