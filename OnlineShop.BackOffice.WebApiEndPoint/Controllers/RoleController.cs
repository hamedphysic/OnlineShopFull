using Microsoft.AspNetCore.Mvc;
using OnlineShopBackOfficeApplication.Dtos.UserManagementAppDto.RoleAppDto;
using OnlineShopBackOfficeApplication.Services.Contracts;
using PublicTools.Resources;

namespace OnlineShop.BackOffice.WebApiEndPoint.Controllers
{
    //[Route("api/Role")]
    //[ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("RegisterRole")]
        public async Task<IActionResult> Post(RegisterRoleAppDto model)
        {
            if (!ModelState.IsValid) { return Json(MessageResource.Error_ThisFieldIsMandatory); }
            
            var resualt = await _roleService.Register(model);
            if (!resualt.IsSuccess) { return new JsonResult(resualt.ErrorMessage); }
            
            return new JsonResult(resualt);

        }
        [HttpPut("UpdateRole")]
        public async Task<IActionResult> Put(PutRoleAppDto model)
        {
            if (!ModelState.IsValid) { return Json(MessageResource.Error_ThisFieldIsMandatory); }

            var resualt = await _roleService.Put(model);
            if (!resualt.IsSuccess) { return new JsonResult(resualt.ErrorMessage); }

            return new JsonResult(resualt);

        }
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> Delete(DeleteRoleAppDto model)
        {
            if (!ModelState.IsValid) { return Json(MessageResource.Error_ThisFieldIsMandatory); }

            var resualt = await _roleService.Delete(model);
            if (!resualt.IsSuccess) { return new JsonResult(resualt.ErrorMessage); }

            return new JsonResult(resualt);

        }
        [HttpGet("GetRole")]
        public async Task<IActionResult> Get(string id)
        {
            if (!ModelState.IsValid) { return Json(MessageResource.Error_ThisFieldIsMandatory); }

            var resualt = await _roleService.Get(id);
            if (!resualt.IsSuccess) { return new JsonResult(resualt.ErrorMessage); }

            return new JsonResult(resualt);

        }
         
        [HttpGet("GetAllRole")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) { return Json(MessageResource.Error_ThisFieldIsMandatory); }

            var resualt = await _roleService.GetAll();
            if (!resualt.IsSuccess) { return new JsonResult(resualt.ErrorMessage); }

            return new JsonResult(resualt);

        }
    }
}
