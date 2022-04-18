using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.Entities.Entities
{
    public class Status : BaseEnum
    {
        public Status(string name, string description) : base(name)
        {
            Description = description;
        }
        public string Description { get; set; }
        public List<Order> OrderList { get; set; } = new List<Order>();
    }
}
