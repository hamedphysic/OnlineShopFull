using Microsoft.AspNetCore.Mvc;
using OnlineShopBackOfficeApplication.Dtos.SaleAppDto.OrderAppDto;
using OnlineShopBackOfficeApplication.Services.Contracts;

namespace OnlineShop.BackOffice.WebApiEndPoint.Controllers
{ 
    [Route("api/order")]
    [ApiController]
    public class BackOfficeOrderController : Controller
    {
        private readonly IOrderServiceBackOffice _orderService;

        public BackOfficeOrderController(IOrderServiceBackOffice orderService)
        {
            _orderService = orderService;
        }
        // گارد برای تمامی کنترلر ها
        // attribute تمام Dto ست شود
        [HttpGet("GetAllOrder")]
        public async Task<IActionResult> GetAll()
        {
            var getAllResult = await _orderService.GetAll();
            return new JsonResult(getAllResult);
        }

        [HttpGet("GetOrder")]
        public async Task<IActionResult> Get(Guid id)
        {
            var getResult = await _orderService.Get(id);
            return new JsonResult(getResult);
        }

        [HttpPost("PostOrder")]
        public async Task<IActionResult> Post(PostOrderAppDto model)
        {
            var postResult = await _orderService.Post(model);
            return new JsonResult(postResult);
        }

        [HttpPut("PutOrder")]
        public async Task<IActionResult> Put(PutOrderAppDto model)
        {
            var putResult = await _orderService.Put(model);
            return new JsonResult(putResult);
        }

        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> Delete(DeleteOrderAppDto model)
        {
            var deleteResult = await _orderService.Delete(model);
            return new JsonResult(deleteResult);
        }
   
    }
}
