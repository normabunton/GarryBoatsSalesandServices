using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarryBoats.Models
{
    public class ProductDelete
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public bool IsARepair { get; set; }
        
        public DateTimeOffset CreatedUtc { get; set; }
       
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
