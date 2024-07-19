using Microsoft.AspNetCore.Identity;
using OnlineshopDmain.Aggregates.UserManagment;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OnlineshopDmain.Frameworks.Abstracts;
using Onlineshop.EFCore.FrameWorks;
using PublicTools.Constants;



namespace Onlineshop.EFCore
{
    public class OnlineshopDbContext:IdentityDbContext<OnlineShopUser,OnlineShopRole,string,
        IdentityUserClaim<string>,
        OnlineShopUserRole,
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>,
        IdentityUserToken<string>
        >
    {
        public OnlineshopDbContext(DbContextOptions<OnlineshopDbContext> options) : base(options)
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DatabaseConstants.Schemas.Identity);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.RegisterAllEntities<IDbSetEntity>(typeof(IDbSetEntity).Assembly);

            //modelBuilder.Entity<OrderHeader>().HasOne(oh => oh.Buyer).WithMany().OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<OrderHeader>().HasOne(oh => oh.Seller).WithMany().OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }



    }
}
