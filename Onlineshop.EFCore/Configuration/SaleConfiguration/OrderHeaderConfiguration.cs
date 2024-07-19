using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineshopDmain.Aggregates.Sale;
using PublicTools.Constants;

namespace Onlineshop.EFCore.Configuration.SaleConfiguration
{
    public class OrderHeaderConfiguration : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.ToTable("OrderHeader", DatabaseConstants.Schemas.Model);
            builder.HasKey(oh => oh.Id);
            builder.Property(oh => oh.SellerId).IsRequired();
            builder.Property(oh => oh.BuyerId).IsRequired();
            builder.Property(oh => oh.Code).IsRequired().IsUnicode();
           

            builder.Property(oh => oh.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(oh => oh.DateCreatedLatin).IsRequired();
            builder.Property(oh => oh.IsModified).HasDefaultValue(false);
            builder.Property(oh => oh.IsDeleted).HasDefaultValue(false);
            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.HasOne(oh => oh.Buyer).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(oh => oh.Seller).WithMany().OnDelete(DeleteBehavior.Restrict);

        }
    }
}
