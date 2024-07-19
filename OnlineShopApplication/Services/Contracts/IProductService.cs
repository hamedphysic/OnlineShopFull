using OnlineShopBackOfficeApplication.Dtos.SaleAppDto.ProductAppDto;
using ResponseFramework;


namespace OnlineShopBackOfficeApplication.Services.Contracts
{
    public interface IProductService
    {
        Task<IResponse<object>> Post(PostProductAppDto model);
        Task<IResponse<object>> Put(PutProductAppDto model);
        Task<IResponse<object>> Delete(DeleteProductAppDto model);
        Task<IResponse<GetProductAppDto>> Get(Guid id);
        Task<IResponse<List<GetProductAppDto>>> GetAll();
    

    }
}
