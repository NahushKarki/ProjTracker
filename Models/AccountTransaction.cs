using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models
{
    public class AccountTransaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }

        public string TransactionName { get; set; }

        public string TransactionDescription { get; set; }

        public string TransactionType { get; set; }

        public Boolean Debt { get; set; }

        public DateTime TransactionDate { get; set; }
    }
  
}
