namespace PublicTools.Constants
{
    
    public class DatabaseConstants
    {
        
        public static class Schemas
        {
            public const string Identity = "UserManagement";
            public const string Model = "Sale";
        }
        public static class AdminUser
        {
            public const string GodAdminId = "1";
            public const string GodAdminFirstName = "Hamed";
            public const string GodAdminLastName = "Pazuki";
            public const string GodAdminNationalId = "0123456789";
            public const string GodAdminUserName = "GodAdmin";
            public const string GodAdminPassword = "1";
            public const string GodAdminCellPhone = "09357622190";

        }
        public static class RollUser
        {
            public const string GodAdminId = "1";
            public const string GodAdminName = "GodAdmin";
            public const string GodAdminNormalizedName = "GODADMIN";
            public const string GodAdminConcurrencyStamp = "1";

            public const string AdminId = "2";
            public const string AdminName = "Admin";
            public const string AdminNormalizedName = "ADMIN";
            public const string AdminConcurrencyStamp = "2";
        }
        public static class CheckConstraints
        {
                     
          // public const string OnlyNumericalTitle = "OnlyNumerical";
            public const string OnlyNationalIdTitle = "OnlyNationalId";
            public const string OnlyPhoneTitle = "OnlyNumerical";

            //public const string OnlyNumerical = "NOT LIKE '%[^0-9]%'";
            public const string OnlyTenDigit = "NationalId LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'";
            public const string OnlyPhoneNumber = "Cellphone LIKE '[0-0][9-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'";
        }
    }
}
