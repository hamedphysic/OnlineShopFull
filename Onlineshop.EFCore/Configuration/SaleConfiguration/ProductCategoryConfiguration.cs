using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineshopDmain.Aggregates.Sale;
using PublicTools.Constants;

namespace Onlineshop.EFCore.Configuration.SaleConfiguration
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory", DatabaseConstants.Schemas.Model);
            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.Title).IsRequired();
            builder.Property(pc => pc.Id).UseIdentityColumn();
        }
    }
}
