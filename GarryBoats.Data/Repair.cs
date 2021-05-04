using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarryBoats.Data
{
    public class Repair
    {
        [Key]
        public int RepairId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string RepairPersonId { get; set; }
        [Required]
        [Display(Name ="Your Repair Details")]
        public string RepairDetails { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Product { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
