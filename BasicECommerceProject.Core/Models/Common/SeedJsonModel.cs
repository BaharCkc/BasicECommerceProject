using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.Core.Models.Common
{
    public class SeedJsonModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        public int Status { get; set; }
        public string OrderSource { get; set; }
        public Lineinterview[] LineInterviews { get; set; }
        public Cargointerview CargoInterview { get; set; }


        public class Cargointerview
        {
            public int Id { get; set; }
            public int OrderId { get; set; }
            public string Name { get; set; }
            public string TrackingNumber { get; set; }
        }

        public class Lineinterview
        {
            public int Id { get; set; }
            public int OrderId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public double Amount { get; set; }
        }

    }
}
