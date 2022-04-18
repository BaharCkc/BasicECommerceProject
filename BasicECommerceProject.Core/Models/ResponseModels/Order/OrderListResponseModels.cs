using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.Core.Models.ResponseModels.Order
{
    public class OrderListResponseModels
    {       
        public string Order_OrderNumber { get; set; }
        public DateTime Order_OrderDate { get; set; }
        public double Order_Amount { get; set; }
        public string Order_Status_Description { get; set; }
        public string Order_OrderSource { get; set; }
        public string Name { get; set; }
        public string TrackingNumber { get; set; }
    }
}
