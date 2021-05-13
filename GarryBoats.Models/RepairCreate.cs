using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarryBoats.Models
{
    public class RepairCreate
    {
        [Required]
        public string RepairDescription { get; set; }
        public string  RepairDetails { get; set; }
    }
}
