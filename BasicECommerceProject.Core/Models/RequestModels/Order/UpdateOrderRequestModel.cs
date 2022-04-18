using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.Core.Models.RequestModels.Order
{
    public class UpdateOrderRequestModel
    {
        public int OrderId { get; set; }
        public string TrackingNumber { get; set; }
    }
}
