using Microsoft.AspNetCore.Mvc;
using OnlineShopBackOfficeApplication.Dtos.SaleAppDto.ProductCategoryAppDto;
using OnlineShopBackOfficeApplication.Services.Contracts;


namespace OnlineShop.BackOffice.WebApiEndPoint.Controllers
{
    [Route("api/ProductCategory")]
    [ApiController]
    public class BackOfficeProductCategoryController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;

        public BackOfficeProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        // چک کردن کنترلر ها

        [HttpPost("PostProductCategory")]
        public async Task<IActionResult> Post(PostProductCategoryAppDto model)
        {
            var postResualt = await _productCategoryService.Post(model);
            return new JsonResult(postResualt);
        }

        [HttpPut("PutProductCategory")]
        public async Task<IActionResult> Put(PutProductCategoryAppDto model)
        {
            var putResualt = await _productCategoryService.Put(model);
            return new JsonResult(putResualt);
        }

        [HttpDelete("DeleteProductCategory")]
        public async Task<IActionResult> Delete(DeleteProductCategoryAppDto model)
        {
            var deleteResualt = await _productCategoryService.Delete(model);
            return new JsonResult(deleteResualt);
        }


        [HttpGet("GetAllProductCategory")]
        public async Task<IActionResult> GetAll()
        {
            var getAllResult = await _productCategoryService.GetAll();
            return new JsonResult(getAllResult);
        }

        [HttpGet("GetProductCategory")]
        public async Task<IActionResult> Find(int id)
        {
            var getResult = await _productCategoryService.Get(id);
            return new JsonResult(getResult);
        }






        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
