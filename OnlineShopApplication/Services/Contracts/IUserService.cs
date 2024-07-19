using OnlineShopBackOfficeApplication.Dtos.UserManagementAppDto.UserAppDto;
using ResponseFramework;


namespace OnlineShopBackOfficeApplication.Services.Contracts
{
    public interface IUserService
    {

        Task<IResponse<object>> Register(RegisterUserAppDto model);
        Task<IResponse<object>> EmailSender(SendEmailUserAppDto model);
    
        Task<IResponse<object>> Put(PutUserAppDto model);
        Task<IResponse<object>> Delete(DeleteUserAppDto model);
        Task<IResponse<GetUserAppDto>> Get(string id);
        Task<IResponse<List<GetUserAppDto>>> GetAll();

    }
}
