using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineshopDmain.Aggregates.UserManagment;
using Onlineshope.RepositoryDesignPttern.Frameworks.Abstracts;
using PublicTools.Resources;
using ResponseFramework;



namespace Onlineshope.RepositoryDesignPttern.Frameworks.Bases
{
    public class BaseRepository<TDbContext, TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
                                                                          where TEntity : class
                                                                          where TDbContext : IdentityDbContext<OnlineShopUser, OnlineShopRole, string,
                                                                              IdentityUserClaim<string>, OnlineShopUserRole, IdentityUserLogin<string>,
                                                                              IdentityRoleClaim<string>, IdentityUserToken<string>>

    {
        public BaseRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }
        protected virtual TDbContext DbContext { get; set; }
        protected virtual DbSet<TEntity> DbSet { get; set; }


        // ---------- select ------------------
        public virtual async Task<IResponse<TEntity>> FindByIdAsync(TPrimaryKey? id)
        {
            if (id == null) { return new Response<TEntity>(MessageResource.Error_ThisFieldIsMandatory);}
            var q = await DbSet.FindAsync(id);
            return q == null ? new Response<TEntity>(MessageResource.Error_FailProcess) : new ResponseFramework.Response<TEntity>(q);
        }
        public virtual async Task<IResponse<List<TEntity>>> Select()
        {
            var allEntity = await DbSet.AsNoTracking().ToListAsync();
            return new Response<List<TEntity>>(allEntity);
        }
        // ----------- insert ------------------

        public virtual async Task<IResponse<object>> InsertAsync(TEntity entity)
        {
            await using (DbContext)
            {
                DbSet.Add(entity);
                await SaveChanges();
                return new Response<object>(entity);
            }
        }

        // -------------- update ---------------

        public virtual async Task<IResponse<object>> UpdateAsync(TEntity entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
            return new Response<object>(entity);
        }

        // ------------ delete -----------------------------
        public virtual async Task<IResponse<object>> DeleteAsync(TPrimaryKey id)
        {
          if(id == null) { return new Response<object>(MessageResource.Error_ThisFieldIsMandatory); }
            var entityToDelete = DbSet.FindAsync(id).Result;

            if (entityToDelete == null) return new Response<object>(MessageResource.Error_FailProcess);
            DbSet.Remove(entityToDelete);
            await SaveChanges();
            return new Response<object>(entityToDelete);
            
           
        }

        public virtual async Task<IResponse<object>> DeleteAsync(TEntity entityToDelete)
        {
            if (DbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
            await SaveChanges();
            return new Response<object>(entityToDelete);
        }

      //------------ save ----------------------------------           

        public virtual async Task SaveChanges()
        {
            await DbContext.SaveChangesAsync();
        }

      

  
    }
}
