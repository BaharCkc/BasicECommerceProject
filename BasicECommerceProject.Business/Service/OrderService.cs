using BasicECommerceProject.Business.IService;
using BasicECommerceProject.Business.IUnitOfWorks;
using BasicECommerceProject.Core.Models.Common;
using BasicECommerceProject.Core.Models.RequestModels.Order;
using BasicECommerceProject.Core.Models.ResponseModels.Line;
using BasicECommerceProject.Core.Models.ResponseModels.Order;
using BasicECommerceProject.DataAccess.DbContexts;
using BasicECommerceProject.Entities.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.Business.Service
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService(ECommerceDbContext db, IUnitOfWork uow) : base(db, uow)
        {

        }

        public async Task<BaseResponseModel> GetAllOrderLines()
        {
            var result = new BaseResponseModel();
            var oderLines = await _dbContext.Line.Where(b => !b.IsDeleted).ToListAsync();

            if (oderLines.Any())
            {
                result.Data = oderLines.Select(b => b.Adapt<LineListResponseModel>()).ToList();
            }

            else
            {
                result.Data = null;
            }

            result.StatusCode = 200;
            result.Message = "Siparişler listelendi.";
            return result;
        }

        public async Task<BaseResponseModel> GetAllOrders()
        {
            var result = new BaseResponseModel();
            //var orderList = await _dbContext.Order.Where(b => !b.IsDeleted).Include(b => b.CargoList).Include(b => b.LineList).Include(b => b.Status).ToListAsync();

            var orders = await _dbContext.Cargo.Where(b => !b.IsDeleted).Include(b => b.Order).ThenInclude(b => b.Status).ToListAsync();
            if (orders.Any())
            {
                result.Data = orders.Select(b => b.Adapt<OrderListResponseModels>()).ToList();
            }
            else
            {
                result.Data = null;
            }

            result.StatusCode = 200;
            result.Message = "Siparişler listelendi.";
            return result;
        }

        public async Task<BaseResponseModel> GetDailyOrderLines()
        {
            var result = new BaseResponseModel();
            var orderList = await _dbContext.Order.Where(b => !b.IsDeleted).Include(b => b.LineList).ToListAsync();

            var resList = new List<DailyOrderResponseModel>();


            foreach (var item in orderList)
            {
                var res = new DailyOrderResponseModel();

                var startDate = DateTime.MinValue;
                var endDate = DateTime.MinValue;

                foreach (var line in item.LineList)
                {
                    var findRes = resList.Where(b => b.ProductName == line.ProductName).FirstOrDefault();
                    if (findRes != null)
                    {
                        if (item.OrderDate < findRes.StartDate && item.OrderDate < findRes.EndDate)
                        {
                            findRes.StartDate = item.OrderDate;

                        }
                        if (item.OrderDate > findRes.EndDate && item.OrderDate > findRes.StartDate)
                        {
                            findRes.EndDate = item.OrderDate;
                        }
                    }
                    else
                    {
                        res.ProductName = line.ProductName;
                        res.StartDate = item.OrderDate;
                        res.EndDate = item.OrderDate;

                        resList.Add(res);
                    }
                }

            }

            foreach (var item in resList)
            {

                var diffDate = (item.EndDate - item.StartDate).TotalDays;
                var avarage = 0.0;
                if (diffDate != 0)
                {
                    avarage = orderList.Count / diffDate;
                }
                else
                {
                    avarage = 0.0;
                }

                item.Frequency = avarage;
            }
            result.Data = resList;
            result.StatusCode = 200;
            return result;
        }

        public async Task<BaseResponseModel> UpdateTrackingNumber(UpdateOrderRequestModel model)
        {
            var result = new BaseResponseModel();
            if (model.OrderId != 0)
            {
                var cargo = await _dbContext.Cargo.Where(b => !b.IsDeleted && b.OrderId == model.OrderId).FirstOrDefaultAsync();
                if (cargo != null)
                {
                    cargo.TrackingNumber = model.TrackingNumber;
                    cargo.UpdateDate = DateTime.Now;

                    var isSave = await _uow.CommitAsync();
                    if (isSave)
                    {
                        result.Data = null;
                        result.Message = "Kargo numarası güncellendi.";
                        result.StatusCode = 200;
                        return result;
                    }

                }
            }
            result.Data = null;
            result.Message = "Kargo numarası güncellenirken hata oluştu";
            result.StatusCode = 404;
            result.IsError = true;
            return result;
        }

    }
}
