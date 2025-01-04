﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public int CurrencyId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; } 

        public string Phone { get; set; }

        public string CurrencyCode { get; set; }
    }
   
}
