using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopOfficeApplication.Dtos.UserManagementAppDto.UserAppDto;
using OnlineshopDmain.Aggregates.UserManagment;
using PublicTools.Resources;


namespace OnlineShop.Office.WebApiEndPoint.Controllers
{
    //[Route("api/Accounting")]
    //[ApiController]
    public class OfficeAccountController : Controller
    {
        private readonly SignInManager<OnlineShopUser> _signInManager;  
        private readonly UserManager<OnlineShopUser> _userManager;


        public OfficeAccountController(UserManager<OnlineShopUser> userManager, SignInManager<OnlineShopUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInAppDto model)
        {
         
            if(!ModelState.IsValid) { return Json(MessageResource.Error_ThisFieldIsMandatory); }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User dont find (add in error list)  ");
                return Json(MessageResource.Error_ThisFieldIsMandatory);
            }
            var result = await _signInManager.PasswordSignInAsync(user , model.Passwrod,model.RememberMe ,false);
           if (!result.Succeeded) 
            {
                ModelState.AddModelError("", "Invalid UserName or Password!");
                return Json(MessageResource.Error_ThisFieldIsMandatory);

            }
           return new JsonResult(model);
        }
      
        [HttpPost("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Json("SignOut");
        }

    }
}
