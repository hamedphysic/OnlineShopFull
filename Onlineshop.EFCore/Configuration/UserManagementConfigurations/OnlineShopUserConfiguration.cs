using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineshopDmain.Aggregates.UserManagment;
using PublicTools.Constants;


namespace Onlineshop.EFCore.Configuration.UserManagementConfigurations
{
    public class OnlineShopUserConfiguration: IEntityTypeConfiguration<OnlineShopUser>
    {
        public void Configure(EntityTypeBuilder<OnlineShopUser> builder)
        {
            // Defult User  ------------------
            builder.ToTable(nameof(OnlineShopUser))
           .HasData(
           new OnlineShopUser
           {
               Id = DatabaseConstants.AdminUser.GodAdminId,
               FirstName=DatabaseConstants.AdminUser.GodAdminFirstName,
               LastName=DatabaseConstants.AdminUser.GodAdminLastName,
               NationalId = DatabaseConstants.AdminUser.GodAdminNationalId,
               NationalIdConfirmed = true,
               UserName = DatabaseConstants.AdminUser.GodAdminUserName,
               PasswordHash = DatabaseConstants.AdminUser.GodAdminPassword,
               Cellphone = DatabaseConstants.AdminUser.GodAdminCellPhone
           }
           );

            // Conigure  ----------------
                      
           builder.ToTable(table => table.HasCheckConstraint(
           DatabaseConstants.CheckConstraints.OnlyNationalIdTitle,
           DatabaseConstants.CheckConstraints.OnlyTenDigit));
           builder.ToTable(table => table.HasCheckConstraint(
           DatabaseConstants.CheckConstraints.OnlyPhoneTitle,
           DatabaseConstants.CheckConstraints.OnlyPhoneNumber));

            builder.Property(p => p.Cellphone).IsRequired().HasMaxLength(11);
            builder.HasIndex(p => p.Cellphone).IsUnique();

            builder.Property(p => p.NationalId).IsRequired().HasMaxLength(10);
            builder.HasIndex(p => p.NationalId).IsUnique();
            builder.Property(p => p.NationalIdConfirmed).HasDefaultValue(false);

            builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(p => p.DateCreatedLatin).IsRequired().HasDefaultValue(System.DateTime.Now);
            builder.Property(p => p.IsModified).HasDefaultValue(false);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
            builder.HasQueryFilter(p => !p.IsDeleted);



        }
    }
}
