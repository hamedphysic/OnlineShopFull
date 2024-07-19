using Microsoft.EntityFrameworkCore;
using Onlineshop.EFCore;
using OnlineshopDmain.Aggregates.Sale;
using OnlineshopDmain.Aggregates.UserManagment;
using Onlineshope.RepositoryDesignPttern.Contracts;
using Onlineshope.RepositoryDesignPttern.Frameworks.Bases;
using PublicTools.Resources;
using ResponseFramework;


namespace Onlineshope.RepositoryDesignPttern.Services.Sale
{
    public class OrderRepository : BaseRepository<OnlineshopDbContext, OrderHeader, Guid>, IOrderRepository
    {
        public OrderRepository(OnlineshopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IResponse <List<OrderHeader>>> SelectAllOrder()
        {
            var q = await DbSet.Include(od => od.OrderDetails).Include(se => se.Seller).Include(bu => bu.Buyer).AsNoTracking().ToListAsync();
            return q == null ? new Response<List<OrderHeader>>(MessageResource.Error_FailProcess) : new Response<List<OrderHeader>>(q);
        }

        public async Task<IResponse<OrderHeader>> FindOrderByIdAsync(Guid id)
        {
            if (id == null) { return new Response<OrderHeader>(MessageResource.Error_ThisFieldIsMandatory); }

            var q = await DbSet.Include(od => od.OrderDetails).Include(se => se.Seller).Include(bu => bu.Buyer).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return q == null ? new Response<OrderHeader>(MessageResource.Error_FailProcess) : new Response<OrderHeader>(q);
        }

        public async Task<IResponse<object>> ClearAllOrderDetail(OrderHeader entity)
        {
            var trackedUsers = DbContext.ChangeTracker.Entries<OnlineShopUser>();

            foreach (var trackedUser in trackedUsers)
            {
                trackedUser.State = EntityState.Detached;
            }

            DbContext.RemoveRange(entity.OrderDetails);
            return new Response<object>(entity);
        }

        public async Task<IResponse<object>> CreateAllOrderDetail(OrderHeader entity)
        {
           
          DbContext.AddRange(entity.OrderDetails);
          return new Response<object>(entity);
  
        }
    

    }
}
