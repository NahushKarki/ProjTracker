using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tracker.Models;

namespace Tracker.Services.Bank
{
    public class BankService : IBankService
    {
        private readonly string banksFilePath = Path.Combine(AppContext.BaseDirectory, "BankDetails.json");

        public async Task AddBankAsync(BankAccount bank)
        {
            try
            {
                var banks = await LoadBanksAsync();
                bank.BankId = banks.Count > 0 ? banks.Max(b => b.BankId) + 1 : 1;
                banks.Add(bank);
                await SaveBanksAsync(banks);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"Error adding task: {ex.Message}");
                throw; // Rethrow or handle as needed
            }
        }

        public async Task<List<BankAccount>> GetBanksByUserIdAsync(int userId)
        {
            try
            {
                var banks = await LoadBanksAsync();
                // Return tasks filtered by userId or an empty list if tasks is null
                return (banks ?? new List<BankAccount>()).Where(b => b.UserId == userId).ToList();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error retrieving tasks for user {userId}: {ex.Message}");
                return new List<BankAccount>(); // Return an empty list in case of an exception
            }
        }

        private async Task<List<BankAccount>> LoadBanksAsync()
        {
            try
            {
                if (!File.Exists(banksFilePath))
                {
                    // If the file does not exist, create it with an empty list
                    var emptyList = new List<BankAccount>();
                    await SaveBanksAsync(emptyList);
                    return emptyList;
                }

                var json = await File.ReadAllTextAsync(banksFilePath);
                return JsonSerializer.Deserialize<List<BankAccount>>(json) ?? new List<BankAccount>();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error loading tasks: {ex.Message}");
                throw; // Rethrow or handle as needed
            }
        }


        private async Task SaveBanksAsync(List<BankAccount> banks)
        {
            try
            {
                var json = JsonSerializer.Serialize(banks, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(banksFilePath, json);
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
