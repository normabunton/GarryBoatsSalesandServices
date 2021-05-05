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
        [Required]
        [MaxLength(2000, ErrorMessage = "There are too many characters in this field, please add a new repair for more details")]
        public string  RepairDetails { get; set; }
    }
}
