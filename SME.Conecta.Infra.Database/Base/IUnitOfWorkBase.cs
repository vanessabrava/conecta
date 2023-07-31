using SME.Conecta.Infra.Database.MySql.Base;
using System;


namespace SME.Conecta.Infra.Database.Base
{
    public interface IUnitOfWorkBase<TContext> : IDisposable
         where TContext : IDbContext
    {
        int SaveChanges();

        void SetTimeOut(int timeOutInSeconds = 180);
    }
}
