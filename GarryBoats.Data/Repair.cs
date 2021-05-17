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
        public Guid UserId { get; set; }
        [Required]
        public string RepairDescription { get; set; }       
        [Required]
        [Display(Name ="Your Repair Name")]
        public string RepairDetails { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
