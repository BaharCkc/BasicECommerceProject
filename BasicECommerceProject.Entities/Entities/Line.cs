using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.Entities.Entities
{
    public class Line : BaseEntity
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public Order Order { get; set; }
    }
}
