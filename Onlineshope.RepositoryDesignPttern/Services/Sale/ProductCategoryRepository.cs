using Onlineshop.EFCore;
using OnlineshopDmain.Aggregates.Sale;
using Onlineshope.RepositoryDesignPttern.Contracts;
using Onlineshope.RepositoryDesignPttern.Frameworks.Bases;


namespace Onlineshope.RepositoryDesignPttern.Services.Sale
{
    public class ProductCategoryRepository : BaseRepository<OnlineshopDbContext, ProductCategory, int>,IProductCategoryRepository
    {
        public ProductCategoryRepository(OnlineshopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
