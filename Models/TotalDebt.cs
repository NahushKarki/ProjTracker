﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models
{
    public class TotalDebt
    {
        public int DebtId { get; set; }
        public int UserId { get; set; }

        public string DebtDescription { get; set; }

        public string DebtType { get; set; }
    }
}