using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.Entities.Entities
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        public int StatusId { get; set; }
        public string OrderSource { get; set; }
        public Status Status { get; set; }
        public List<Cargo> CargoList { get; set; } = new List<Cargo>();
        public List<Line> LineList { get; set; } = new List<Line>();
    }
}
