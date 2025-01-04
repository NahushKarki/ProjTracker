using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Tracker.Models;

namespace Tracker.Services.Transaction
{
    public class TransactionService : ITransactionService
    {
        private readonly string transactionsFilePath = Path.Combine(AppContext.BaseDirectory, "TransactionDetails.json");

        public async Task AddTransactionAsync(AccountTransaction transaction)
        {
            try
            {
                var transactions = await LoadTransactionsAsync();
                transaction.TransactionId = transactions.Count > 0 ? transactions.Max(t => t.TransactionId) + 1 : 1;
                transactions.Add(transaction);
                await SaveTransactionsAsync(transactions);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"Error adding task: {ex.Message}");
                throw; // Rethrow or handle as needed
            }
        }

        public async Task<List<AccountTransaction>> GetTransactionsByUserIdAsync(int userId)
        {
            try
            {
                var transactions = await LoadTransactionsAsync();
                // Return tasks filtered by userId or an empty list if tasks is null
                return (transactions ?? new List<AccountTransaction>()).Where(t => t.UserId == userId).ToList();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error retrieving tasks for user {userId}: {ex.Message}");
                return new List<AccountTransaction>(); // Return an empty list in case of an exception
            }
        }

        private async Task<List<AccountTransaction>> LoadTransactionsAsync()
        {
            try
            {
                if (!File.Exists(transactionsFilePath))
                {
                    // If the file does not exist, create it with an empty list
                    var emptyList = new List<AccountTransaction>();
                    await SaveTransactionsAsync(emptyList);
                    return emptyList;
                }

                var json = await File.ReadAllTextAsync(transactionsFilePath);
                return JsonSerializer.Deserialize<List<AccountTransaction>>(json) ?? new List<AccountTransaction>();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error loading tasks: {ex.Message}");
                throw; // Rethrow or handle as needed
            }
        }


        private async Task SaveTransactionsAsync(List<AccountTransaction> transactions)
        {
            try
            {
                var json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(transactionsFilePath, json);
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
