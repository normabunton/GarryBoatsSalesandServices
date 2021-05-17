using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarryBoats.Models
{
    public class RepairPersonDelete
    {
        public int RepairPersonId { get; set; }
        public string RepairPersonName { get; set; }
        public string RepairPersonLocation { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
