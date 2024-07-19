
using System.ComponentModel.DataAnnotations;


namespace OnlineShopOfficeApplication.Dtos.UserManagementAppDto.UserAppDto
{
    public class SignInAppDto
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Passwrod { get; set; }

        public bool RememberMe { get; set; }

    }
}
