using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineshopDmain.Aggregates.UserManagment;
using PublicTools.Constants;


namespace Onlineshop.EFCore.Configuration.UserManagementConfigurations
{
    public class OnlineShopUserRoleConfiguration : IEntityTypeConfiguration<OnlineShopUserRole>
    {
        public void Configure(EntityTypeBuilder<OnlineShopUserRole> builder)
        {
            builder.ToTable(nameof(OnlineShopUserRole))
                .HasData(
                    new OnlineShopUserRole() { UserId = DatabaseConstants.AdminUser.GodAdminId, RoleId = DatabaseConstants.RollUser.GodAdminId }
                       );
            builder.HasKey(p => new
            {
                p.UserId,
                p.RoleId,
            });
        }

    }
}
