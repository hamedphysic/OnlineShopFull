using Microsoft.EntityFrameworkCore;
using Onlineshop.EFCore;
using OnlineshopDmain.Aggregates.Sale;
using Onlineshope.RepositoryDesignPttern.Contracts;
using Onlineshope.RepositoryDesignPttern.Frameworks.Bases;
using PublicTools.Resources;
using ResponseFramework;


namespace Onlineshope.RepositoryDesignPttern.Services.Sale
{
    public class ProductRepository : BaseRepository<OnlineshopDbContext, Product, Guid>,IProductRepository
    {
        public ProductRepository(OnlineshopDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IResponse<Product>> SelectForUpdateAsync(Guid id)
        {
            if (id == null) { return new Response<Product>(MessageResource.Error_ThisFieldIsMandatory); }
           
            var q = await DbSet.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return q == null ? new Response<Product>(MessageResource.Error_FailProcess) : new Response<Product>(q);
        }
    }
}
