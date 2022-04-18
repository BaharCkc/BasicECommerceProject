using BasicECommerceProject.Core.Models.Common;
using BasicECommerceProject.Core.Models.RequestModels.Order;
using BasicECommerceProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.Business.IService
{
    public interface IOrderService : IBaseService<Order>
    {
        Task<BaseResponseModel> GetAllOrders();
        Task<BaseResponseModel> GetAllOrderLines();
        Task<BaseResponseModel> GetDailyOrderLines();
        Task<BaseResponseModel> UpdateTrackingNumber(UpdateOrderRequestModel model);
    }
}
