using OnlineshopDmain.Aggregates.Sale;
using Onlineshope.RepositoryDesignPttern.Frameworks.Abstracts;

namespace Onlineshope.RepositoryDesignPttern.Contracts
{
    public interface IProductCategoryRepository:IRepository<ProductCategory,int>
    {
    }
}
