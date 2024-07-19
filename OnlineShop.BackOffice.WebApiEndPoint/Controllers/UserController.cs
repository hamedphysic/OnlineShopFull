﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using OnlineShopBackOfficeApplication.Dtos.UserManagementAppDto.UserAppDto;
using OnlineShopBackOfficeApplication.Services.Contracts;
using OnlineshopDmain.Aggregates.UserManagment;
using PublicTools.Resources;
using System.Text;

namespace OnlineShop.BackOffice.WebApiEndPoint.Controllers
{
    //[Route("api/User")]
    //[ApiController]
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly UserManager<OnlineShopUser> _userManager;

        public UserController(IUserService userService , UserManager<OnlineShopUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        
        }



        [HttpPost("RegisterUser")]
        public async Task<IActionResult> Post(RegisterUserAppDto model)
        {
            if(!ModelState.IsValid) { return Json(MessageResource.Error_ThisFieldIsMandatory); }
                   


            var registerResualt = await _userService.Register(model);
            if (!registerResualt.IsSuccess) { return new JsonResult(registerResualt.ErrorMessage);}
           
            
            /*

                //------------ send mail -----------------------------
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null) { return new JsonResult("Email Confirm Don't send"); }

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

               //this HttpRequest req;
               //req.Scheme;
               //req.Host.Host;
               //req.Host.Port;
            
              string callBackUrl = Url.ActionLink("ConfirmEmail", "User", Request.Scheme);
             //  string callBackUrl = Url.Action("ConfirmEmail", "User", values: new { user.Id, token }, protocol: Request.Scheme);
             // string callBackUrl = Url.Content($"~/User/ConfirmEmail?{user.Id}?{token}");




              string body = $"<p> Pease click link to active your account </p> </br> <a href={callBackUrl}> Click Here </a>";

                var emailmodel = new SendEmailUserAppDto
                {
                    To = user.Email,
                    Subject = "taaaaaaaiiiidd",
                    Body = body
                };

                await _userService.EmailSender(emailmodel);
            //------------------------------------------------------------------
         */


            return new JsonResult(registerResualt);
       
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Put(PutUserAppDto model)
        {
            if (!ModelState.IsValid) { return Json(MessageResource.Error_ThisFieldIsMandatory); }

            var resualt = await _userService.Put(model);
            if (!resualt.IsSuccess) { return new JsonResult(resualt.ErrorMessage); }
    
            return new JsonResult(resualt);

        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> Delete(DeleteUserAppDto model)
        {
            if (!ModelState.IsValid) { return Json(MessageResource.Error_ThisFieldIsMandatory); }

            var resualt = await _userService.Delete(model);
            if (!resualt.IsSuccess) { return new JsonResult(resualt.ErrorMessage); }

            return new JsonResult(resualt);

        }
        [HttpGet("GetUser")]
        public async Task<IActionResult> Get(string id)
        {
            if (!ModelState.IsValid) { return Json(MessageResource.Error_ThisFieldIsMandatory); }

            var resualt = await _userService.Get(id);
            if (!resualt.IsSuccess) { return new JsonResult(resualt.ErrorMessage); }

            return new JsonResult(resualt);

        }
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) { return Json(MessageResource.Error_ThisFieldIsMandatory); }

            var resualt = await _userService.GetAll();
            if (!resualt.IsSuccess) { return new JsonResult(resualt.ErrorMessage); }

            return new JsonResult(resualt);

        }


        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null) { return new JsonResult("User or token is null"); }
          
            var user = await _userManager.FindByIdAsync(userId);
            
            if (user == null) { return new JsonResult("User is null"); }
            
            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));

            var result = await _userManager.ConfirmEmailAsync(user, token);
         
            if (!result.Succeeded){ return new JsonResult("Email Confirm Fail"); }

            return new JsonResult("Email Confirm Done");
                       
        }
    
    }
}