using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineshopDmain.Aggregates.UserManagment;
using PublicTools.Constants;

namespace Onlineshop.EFCore.Configuration.UserManagementConfigurations
{
    public class OnlineShopRoleConfiguration:IEntityTypeConfiguration<OnlineShopRole>
    {
        public void Configure(EntityTypeBuilder<OnlineShopRole> builder)
        {

            builder.ToTable(nameof(OnlineShopRole)).
                HasData(
                new OnlineShopRole()
                {
                    Id = DatabaseConstants.RollUser.GodAdminId,
                    Name = DatabaseConstants.RollUser.GodAdminName,
                    NormalizedName = DatabaseConstants.RollUser.GodAdminNormalizedName,
                    ConcurrencyStamp = DatabaseConstants.RollUser.GodAdminConcurrencyStamp,
                },
                new OnlineShopRole()
                {
                    Id = DatabaseConstants.RollUser.AdminId,
                    Name = DatabaseConstants.RollUser.AdminName,
                    NormalizedName = DatabaseConstants.RollUser.AdminNormalizedName,
                    ConcurrencyStamp = DatabaseConstants.RollUser.AdminConcurrencyStamp,
                }
            );

        }
    }
}
