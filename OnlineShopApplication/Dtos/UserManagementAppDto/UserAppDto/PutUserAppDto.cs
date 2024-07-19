
namespace OnlineShopBackOfficeApplication.Dtos.UserManagementAppDto.UserAppDto
{
    public class PutUserAppDto
    {
        public string Id { get; set; }

        public string Passwrod { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> Roles { get; set; }
    }
}
