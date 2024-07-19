using System.ComponentModel.DataAnnotations;


namespace OnlineShopOfficeApplication.Dtos.UserManagementAppDto.UserAppDto
{
    public class SignUpUserAppDto
    {

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Passwrod { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "CellPhone is required")]
        public string CellPhone { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "NationalId is required")]
        public string NationalId { get; set; }

    }
}
