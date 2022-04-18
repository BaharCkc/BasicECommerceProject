using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.Entities.Entities
{
    public class Cargo : BaseEntity
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string TrackingNumber { get; set; }
        public Order Order { get; set; }        

    }
}
