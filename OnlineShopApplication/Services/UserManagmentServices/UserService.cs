using Microsoft.AspNetCore.Identity;
using OnlineShopBackOfficeApplication.Dtos.UserManagementAppDto.UserAppDto;
using OnlineShopBackOfficeApplication.Services.Contracts;
using OnlineshopDmain.Aggregates.UserManagment;
using PublicTools.Resources;
using PublicTools.Tools;
using ResponseFramework;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Data;
using OnlineShopBackOfficeApplication.Dtos.UserManagementAppDto.RoleAppDto;


namespace OnlineShopBackOfficeApplication.Services.UserManagmentServices
{
    public class UserService : IUserService

    {
        private readonly UserManager<OnlineShopUser> _userManager;
        private readonly RoleManager<OnlineShopRole> _roleManager;


        public UserService(UserManager<OnlineShopUser> userManager, RoleManager<OnlineShopRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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
        public async Task<IResponse<List<GetUserAppDto>>> GetAll()
        {
            var selectedusers = await _userManager.Users.ToListAsync();
            if (selectedusers == null) { return new Response<List<GetUserAppDto>>(MessageResource.Error_FailProcess); }

           var users = selectedusers.Select(item => new GetUserAppDto()
            {
                Id = item.Id,
                UserName = item.UserName,
                Passwrod = item.PasswordHash,
                Email = item.Email,
                CellPhone = item.Cellphone,
                FirstName = item.FirstName,
                LastName = item.LastName,
                NationalId = item.NationalId
            }).ToList();

            return new Response<List<GetUserAppDto>>(true, MessageResource.Info_SuccessfullProcess, string.Empty, users, HttpStatusCode.OK);




        }
        public async Task<IResponse<object>> Register(RegisterUserAppDto model)
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

            foreach (var item in model.Roles)
            {
              await _userManager.AddToRoleAsync(user, item);
            }

            return new Response<object>(user);

        }
        public async Task<IResponse<object>> Put(PutUserAppDto model)
        {
            
            //------------
            if (model == null) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
            if (model.Passwrod == string.Empty || model.FirstName == string.Empty || model.LastName==string.Empty) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
            //------------

            var selecteduser = await _userManager.FindByIdAsync(model.Id);
            if (selecteduser == null) return new Response<object>(MessageResource.Error_FailProcess);
            // ----------------------------
          var  allRole = await _roleManager.Roles.ToListAsync();
            bool chek;
            foreach (var item in model.Roles)
            {
                chek = false;
                foreach (var role in allRole)
                {
                    if (item == role.Name) { chek = true; }
                }
                if (chek == false) return new Response<object>(MessageResource.Error_FailProcess);
            }
            //-----------------------------


            selecteduser.FirstName=model.FirstName;
            selecteduser.LastName=model.LastName;
            

            var newPasswordHash = _userManager.PasswordHasher.HashPassword(selecteduser, model.Passwrod);
            selecteduser.PasswordHash = newPasswordHash;

            var currentRoles = await _userManager.GetRolesAsync(selecteduser);
            foreach (var item in currentRoles)
            {
                if (!model.Roles.Any(c => c == item))
                {
                await _userManager.RemoveFromRoleAsync(selecteduser, item);
                }
            }
            foreach (var item in model.Roles)
            {
                var isInRole = await _userManager.IsInRoleAsync(selecteduser, item);
                if (!isInRole)
                {
                   await _userManager.AddToRoleAsync(selecteduser, item);
                }
            }
        
           
            var Result = await _userManager.UpdateAsync(selecteduser);

            if (!Result.Succeeded) return new Response<object>(MessageResource.Error_FailProcess);
            //------------
            return new Response<object>( true, MessageResource.Info_SuccessfullProcess, string.Empty,selecteduser , HttpStatusCode.OK);
        }
        public async Task<IResponse<object>> Delete(DeleteUserAppDto model)
        {
            //------------
            if (model == null) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
            //------------

            var selecteduser = await _userManager.FindByIdAsync(model.Id);
            if (selecteduser == null) return new Response<object>(MessageResource.Error_FailProcess);


            selecteduser.IsDeleted= true;
            selecteduser.DateSoftDeletedLatin = DateTime.Now;
            selecteduser.DateSoftDeletedPersian = DateTime.Now.DateToPersian();

                    
            var Result = await _userManager.UpdateAsync(selecteduser);

            if (!Result.Succeeded) return new Response<object>(MessageResource.Error_FailProcess);
            //------------
            return new Response<object>(true, MessageResource.Info_SuccessfullProcess, string.Empty, selecteduser, HttpStatusCode.OK);
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



     
    }
}
