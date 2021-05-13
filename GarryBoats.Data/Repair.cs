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
       
        //public string RepairPersonId { get; set; }
        [Required]
        [Display(Name ="Your Repair Name")]
        public string RepairDetails { get; set; }
        [Required]
        public string RepairDescription { get; set; }
        
        //public string Location { get; set; }

        //public string Product { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
