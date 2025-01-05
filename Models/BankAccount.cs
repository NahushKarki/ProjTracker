using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models
{
    public class BankAccount
    {
        public int BankId { get; set; }

        public int UserId { get; set; }

        public int TransactionId { get; set; }

        public int DebtId { get; set; }

        public string BankName { get; set; }

        public string BankDescription { get; set; }

        public string BankType { get; set; }

        public int BankBalance { get; set; }

        public DateTime BankRegisteredDate { get; set; }
      
    }
}
