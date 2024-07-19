using OnlineshopDmain.Aggregates.Sale;
using Onlineshope.RepositoryDesignPttern.Frameworks.Abstracts;
using ResponseFramework;

namespace Onlineshope.RepositoryDesignPttern.Contracts
{
    public interface IOrderRepository:IRepository<OrderHeader,Guid>
    {
        public Task<IResponse<OrderHeader>> FindOrderByIdAsync(Guid id);
        public Task<IResponse<List<OrderHeader>>> SelectAllOrder();
        public Task<IResponse<object>> ClearAllOrderDetail(OrderHeader entity);
        public Task<IResponse<object>> CreateAllOrderDetail(OrderHeader entity);

    }
}
