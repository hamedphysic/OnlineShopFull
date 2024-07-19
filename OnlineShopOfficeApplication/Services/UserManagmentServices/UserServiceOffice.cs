using Microsoft.AspNetCore.Identity;
using OnlineShopOfficeApplication.Dtos.UserManagementAppDto.UserAppDto;
using OnlineShopOfficeApplication.Services.Contracts;
using OnlineshopDmain.Aggregates.UserManagment;
using PublicTools.Resources;
using PublicTools.Tools;
using ResponseFramework;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Data;



namespace OnlineShopBackOfficeApplication.Services.UserManagmentServices
{
    public class UserServiceOffice : IUserServiceOffice

    {
        private readonly UserManager<OnlineShopUser> _userManager;
       
        public UserServiceOffice(UserManager<OnlineShopUser> userManager)
        {
            _userManager = userManager;
          
        }


        public async Task<IResponse<GetUserAppDto>> Get(string id)
        {
            if (id == null) return new Response<GetUserAppDto>(MessageResource.Error_TheParameterIsNull);
            var selecteduser = await _userManager.FindByIdAsync(id);
            if (selecteduser == null) { return new Response<GetUserAppDto>(MessageResource.Error_FailProcess); }
           
            var user = new GetUserAppDto
            {
                UserName = selecteduser.UserName,
                Passwrod = selecteduser.PasswordHash,
                Email = selecteduser.Email,
                CellPhone = selecteduser.Cellphone,
                FirstName = selecteduser.FirstName,
                LastName = selecteduser.LastName,
                NationalId = selecteduser.NationalId,
            };
           

            return new Response<GetUserAppDto>(true, MessageResource.Info_SuccessfullProcess, string.Empty, user, HttpStatusCode.OK);


        }
        public async Task<IResponse<object>> EmailSender(SendEmailUserAppDto model)
        {
            MailMessage message = new MailMessage()
            {
                From = new MailAddress("pazuki.physic@live.com", "Ozhan"),
                To = { model.To },
                Subject = model.Subject,
                Body = model.Body,
                BodyEncoding = UTF8Encoding.UTF8,
                IsBodyHtml = true,
            };

            SmtpClient smtpClient = new SmtpClient()
            {
                //Host = "smtp.gmail.com",
                Host = "smtp-mail.outlook.com",
                Port = 587,
                Credentials = new NetworkCredential("pazuki.physic@live.com", "a313..."),
                EnableSsl = true,
            };
            smtpClient.Send(message);

            return new Response<object>(model);
           
        }
        public async Task<IResponse<object>> SignUp(SignUpUserAppDto model)
        {
            if (model == null) { return new Response<object>(MessageResource.Error_FailProcess); }
            var user = new OnlineShopUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Cellphone = model.CellPhone,
                FirstName = model.FirstName,
                LastName = model.LastName,
                NationalId = model.NationalId,
                DateCreatedLatin = DateTime.Now,
                DateCreatedPersian = DateTime.Now.DateToPersian()
            };

            var result = await _userManager.CreateAsync(user, model.Passwrod);
            if (!result.Succeeded) { return new Response<object>(MessageResource.Error_FailProcess); }
            await _userManager.AddToRoleAsync(user, "seller");
        

            return new Response<object>(user);
        }
    }
}
