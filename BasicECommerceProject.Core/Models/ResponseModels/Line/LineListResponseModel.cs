using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.Core.Models.ResponseModels.Line
{
    public class LineListResponseModel
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
    }
}
