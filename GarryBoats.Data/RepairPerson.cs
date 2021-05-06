using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarryBoats.Data
{
    public class RepairPerson
    {
        [Key]
        public int RepairPersonId { get; set; }
        [Required]
        public string RepairPersonName { get; set; }
        [Required]
        public string RepairPersonLocation { get; set; }
        DateTimeOffset CreatedUtc { get; set; }
        DateTimeOffset? ModifiedUtc { get; set; }

    }
}
