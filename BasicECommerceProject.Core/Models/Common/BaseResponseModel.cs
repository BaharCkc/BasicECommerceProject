using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.Core.Models.Common
{
    public class BaseResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
        public object Data { get; set; }
    }

    public class ErrorModel
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
}
