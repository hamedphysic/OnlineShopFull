using OnlineShopBackOfficeApplication.Dtos.UserManagementAppDto.RoleAppDto;
using ResponseFramework;


namespace OnlineShopBackOfficeApplication.Services.Contracts
{
    public interface IRoleService
    {
        Task<IResponse<object>> Register(RegisterRoleAppDto model);
        Task<IResponse<object>> Put(PutRoleAppDto model);
        Task<IResponse<object>> Delete(DeleteRoleAppDto model);
        Task<IResponse<GetRoleAppDto>> Get(string id);
        Task<IResponse<List<GetRoleAppDto>>> GetAll();
    }
}
