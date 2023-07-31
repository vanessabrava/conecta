using SME.Conecta.Infra.CrossCutting.Model;
using SME.Conecta.Infra.Database.Base;
using Microsoft.EntityFrameworkCore;

namespace SME.Conecta.Infra.Database.MySql.Base
{
    public abstract class DbContextBase : DbContext, IDbContext
    {
        protected DbContextBase(DbContextOptions options)
            : base(options)
        {
            SetAutoDetectChanges(false);
            SetTimeOut();
        }

        public void SetAutoDetectChanges(bool enable = true) => ChangeTracker.AutoDetectChangesEnabled = enable;

        public void SetTimeOut(int timeOutInSeconds = 180) => Database.SetCommandTimeout(timeOutInSeconds);

        public virtual DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IEntity => Set<TEntity>();

        public virtual void SetModified<TEntity>(TEntity entity) where TEntity : class, IEntity => Entry(entity).State = EntityState.Modified;

        public virtual void SetDeleted<TEntity>(TEntity entity) where TEntity : class, IEntity => Entry(entity).State = EntityState.Deleted;
    }
}
