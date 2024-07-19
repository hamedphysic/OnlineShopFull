using OnlineShopBackOfficeApplication.Dtos.SaleAppDto.OrderAppDto;
using ResponseFramework;


namespace OnlineShopBackOfficeApplication.Services.Contracts
{ 
    public interface IOrderServiceBackOffice
    {
        Task<IResponse<object>> Post(PostOrderAppDto model);
        Task<IResponse<object>> Put(PutOrderAppDto model);
        Task<IResponse<object>> Delete(DeleteOrderAppDto model);
        Task<IResponse<GetOrderAppDto>> Get(Guid id);
        Task<IResponse<List<GetOrderAppDto>>> GetAll();
    }
}
