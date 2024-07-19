using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShopBackOfficeApplication.Dtos.SaleAppDto.ProductAppDto;
using OnlineShopBackOfficeApplication.Dtos.UserManagementAppDto.RoleAppDto;
using OnlineShopBackOfficeApplication.Services.Contracts;
using OnlineshopDmain.Aggregates.UserManagment;
using PublicTools.Resources;
using ResponseFramework;
using System.Net;
using System.Net.Sockets;


namespace OnlineShopBackOfficeApplication.Services.UserManagmentServices
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<OnlineShopRole> _roleManager;
        private readonly UserManager<OnlineShopUser> _userManager;
  

        public RoleService(RoleManager<OnlineShopRole> roleManager, UserManager<OnlineShopUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
    
        }



        public async Task<IResponse<GetRoleAppDto>> Get(string id)
        {
            if (id == null) return new Response<GetRoleAppDto>(MessageResource.Error_TheParameterIsNull);
            var selectRole = await _roleManager.FindByIdAsync(id);
            if (selectRole == null) return new Response<GetRoleAppDto>(MessageResource.Error_TheParameterIsNull);
            var role = new GetRoleAppDto()
            {
                Name = selectRole.Name
            };

            return new Response<GetRoleAppDto>(true, MessageResource.Info_SuccessfullProcess, string.Empty, role, HttpStatusCode.OK);
        }
        public  async Task<IResponse<List<GetRoleAppDto>>> GetAll()
        {
            var allRole = await _roleManager.Roles.ToListAsync();
            if (allRole == null) return new Response<List<GetRoleAppDto>>(MessageResource.Error_TheParameterIsNull);
            var all = new List<GetRoleAppDto>();
            foreach (var role in allRole) 
            {
                var mapRole = new GetRoleAppDto() { Name = role.Name };
                all.Add(mapRole);
            }
            return new Response<List<GetRoleAppDto>>(true, MessageResource.Info_SuccessfullProcess, string.Empty, all, HttpStatusCode.OK);
        }
        public async Task<IResponse<object>> Register(RegisterRoleAppDto model)
        {
            if (model == null) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
            if (model.Name == string.Empty) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
            var role = new OnlineShopRole
            {
                Name = model.Name
            };
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded) { return new Response<object>(MessageResource.Error_FailProcess); }
            return new Response<object>(role);
        }
        public async Task<IResponse<object>> Put(PutRoleAppDto model)
        {
            if (model == null) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
            if (model.Name == string.Empty) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
            //------------

            var selectedrole = await _roleManager.FindByIdAsync(model.id);
            if (selectedrole == null) return new Response<object>(MessageResource.Error_FailProcess);
            
            selectedrole.Name = model.Name;
            selectedrole.NormalizedName = model.Name.ToUpper();


            var result = await _roleManager.UpdateAsync(selectedrole);
            if (!result.Succeeded) { return new Response<object>(MessageResource.Error_FailProcess); }

            return new Response<object>(selectedrole);
        }
        public async Task<IResponse<object>> Delete(DeleteRoleAppDto model)
        {
            if (model == null) { return new Response<object>(MessageResource.Error_ThisFieldIsMandatory); }
            var role = await _roleManager.FindByNameAsync(model.Name);
            if (role == null) { return new Response<object>(MessageResource.Error_ThisFieldIsMandatory); }
            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded) { return new Response<object>(MessageResource.Error_FailProcess); }

            return new Response<object>(role);
        }

       
    }
}
