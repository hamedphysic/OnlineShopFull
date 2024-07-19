using Microsoft.AspNetCore.Identity;
using OnlineshopDmain.Frameworks.Abstracts;


namespace OnlineshopDmain.Aggregates.UserManagment
{
    public class OnlineShopUser: IdentityUser,IActiveEntity,ICreatedEntity,IModifiedEntity,ISoftDeletedEntity,IDbSetEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public bool NationalIdConfirmed { get; set; }
        public string Cellphone { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreatedLatin { get; set; }
        public string? DateCreatedPersian { get; set; }
        public bool IsModified { get; set; }
        public DateTime DateModifiedLatin { get; set; }
        public string? DateModifiedPersian { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateSoftDeletedLatin { get; set; }
        public string? DateSoftDeletedPersian { get; set; }
    }
}
