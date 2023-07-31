using SME.Conecta.Infra.CrossCutting.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace SME.Conecta.Infra.Database.MySql.Base
{
    public interface IDbContext : IDisposable
    {
        void SetAutoDetectChanges(bool enable = true);

        void SetTimeOut(int timeOutInSeconds = 180);

        int SaveChanges();

        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IEntity;

        void SetModified<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void SetDeleted<TEntity>(TEntity entity) where TEntity : class, IEntity;
    }
}
