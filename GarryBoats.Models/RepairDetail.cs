using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarryBoats.Models
{
    public class RepairDetail
    {
        
        public int RepairID { get; set; }

        public string  RepairDescription { get; set; }
        public string RepairDetails { get; set; }
        //[ForeignKey]
        //public string RepairPersonName { get; set; }
        //[ForeignKey]
        //public string RepairLocation { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }

}
