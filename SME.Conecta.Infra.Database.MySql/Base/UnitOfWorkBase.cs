using System;
using SME.Conecta.Infra.Database.Base;

namespace SME.Conecta.Infra.Database.MySql.Base
{
    public abstract class UnitOfWorkBase<TContext> : IUnitOfWorkBase<TContext>
        where TContext : IDbContext
    {
        private TContext Context { get; }
        private bool Disposed { get; set; } = false;

        protected UnitOfWorkBase(TContext context) => Context = context;

        public virtual int SaveChanges() => Context.SaveChanges();

        public void SetTimeOut(int timeOutInSeconds = 180) => Context.SetTimeOut(timeOutInSeconds);

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
                Context.Dispose();

            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
