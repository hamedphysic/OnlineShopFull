using Microsoft.AspNetCore.Mvc;
using OnlineShopBackOfficeApplication.Dtos.SaleAppDto.ProductAppDto;
using OnlineShopBackOfficeApplication.Services.Contracts;

namespace OnlineShop.BackOffice.WebApiEndPoint.Controllers
{

    [Route("api/Product")]
    [ApiController]
    public class BackOfficeProductController : Controller
    {
        private readonly IProductService _productService;

        public BackOfficeProductController(IProductService productService)
        {
            _productService = productService;
        }



        [HttpPost("PostProduct")]
        public async Task<IActionResult> Post(PostProductAppDto model)
        {
            var postResualt = await _productService.Post(model);
            return new JsonResult(postResualt);
        }

        [HttpPut("PutProduct")]
        public async Task<IActionResult> Put(PutProductAppDto model)
        {
            var putResualt = await _productService.Put(model);
            return new JsonResult(putResualt);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> Delete(DeleteProductAppDto model)
        {
            var deleteResualt = await _productService.Delete(model);
            return new JsonResult(deleteResualt);
        }


        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAll()
        {
            var getAllResult = await _productService.GetAll();
            return new JsonResult(getAllResult);
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> Find(Guid id)
        {
            var getResult = await _productService.Get(id);
            return new JsonResult(getResult);
        }





        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
