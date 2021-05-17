using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarryBoats.Models
{
    public class RepairDelete
    {
        public int RepairId { get; set; }
        public string RepairDescription { get; set; }
        public string RepairDetails { get; set; }


        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
