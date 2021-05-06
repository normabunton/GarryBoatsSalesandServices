using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarryBoats.Models
{
    public class RepairPersonCreate
    {
        [Required]
        public string RepairPersonName { get; set; }
        [Required]
        public string  RepairPersonLocation { get; set; }
    }
}
