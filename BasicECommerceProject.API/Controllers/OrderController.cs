using BasicECommerceProject.Business.IService;
using BasicECommerceProject.Core.Models.RequestModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicECommerceProject.API.Controllers
{
    //[Authorize]
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("getAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _orderService.GetAllOrders();
            return Ok(result);
        }

        [HttpGet]
        [Route("getAllOrderLines")]
        public async Task<IActionResult> GetAllOrderLines()
        {
            var result = await _orderService.GetAllOrderLines();
            return Ok(result);
        }
        [HttpPost]
        [Route("updateTrackingNumber")]
        public async Task<IActionResult> UpdateTrackingNumber([FromBody] UpdateOrderRequestModel model)
        {
            var result = await _orderService.UpdateTrackingNumber(model);
            return Ok(result);
        }
        [HttpGet]
        [Route("getDailyOrderLines")]
        public async Task<IActionResult> GetDailyOrderLines()
        {
            var result = await _orderService.GetDailyOrderLines();
            return Ok(result);
        }
    }
}
