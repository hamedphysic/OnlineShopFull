
using System.ComponentModel.DataAnnotations;


namespace OnlineShopBackOfficeApplication.Dtos.UserManagementAppDto.UserAppDto
{
    public class LoginAppDto
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Passwrod { get; set; }

        public bool RememberMe { get; set; }

    }
}
