using OnlineShopBackOfficeApplication.Dtos.SaleAppDto.ProductCategoryAppDto;
using ResponseFramework;


namespace OnlineShopBackOfficeApplication.Services.Contracts
{
    public interface IProductCategoryService
    {
        Task<IResponse<object>> Post(PostProductCategoryAppDto model);
        Task<IResponse<object>> Put(PutProductCategoryAppDto model);
        Task<IResponse<object>> Delete(DeleteProductCategoryAppDto model);
        Task<IResponse<GetProductCategoryAppDto>> Get(int id);
        Task<IResponse<List<GetProductCategoryAppDto>>> GetAll();
       
    }
}
