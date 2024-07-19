using OnlineshopDmain.Aggregates.Sale;
using Onlineshope.RepositoryDesignPttern.Frameworks.Abstracts;
using ResponseFramework;

namespace Onlineshope.RepositoryDesignPttern.Contracts
{
    public interface IProductRepository:IRepository<Product,Guid>
    {
        public Task<IResponse<Product>> SelectForUpdateAsync(Guid id);
    }
}
