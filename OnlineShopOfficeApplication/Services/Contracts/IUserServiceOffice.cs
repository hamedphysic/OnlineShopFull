using OnlineShopOfficeApplication.Dtos.UserManagementAppDto.UserAppDto;
using ResponseFramework;


namespace OnlineShopOfficeApplication.Services.Contracts
{
    public interface IUserServiceOffice
    {

        Task<IResponse<object>> SignUp(SignUpUserAppDto model);
        Task<IResponse<object>> EmailSender(SendEmailUserAppDto model);
        Task<IResponse<GetUserAppDto>> Get(string id);
   
    }
}
