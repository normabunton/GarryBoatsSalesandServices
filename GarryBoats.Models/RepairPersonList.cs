﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarryBoats.Models
{
    class RepairPersonList
    {
        public int RepairPersonId { get; set; }
        public string RepairPersonName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
