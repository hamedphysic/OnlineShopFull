using System.ComponentModel.DataAnnotations;

namespace OnlineShopBackOfficeApplication.Dtos.UserManagementAppDto.RoleAppDto
{
    public class RegisterRoleAppDto
    {
        [Required]
        public string Name { get; set; }
    }
}
