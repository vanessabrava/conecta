
using SME.Conecta.Infra.Database.Contexts;
using SME.Conecta.Infra.Database.MySql.Base;
using SME.Conecta.Infra.Database.MySql.Contexts;
using SME.Conecta.Infra.Database.UnitOfWork;
using System;

namespace SME.Conecta.Infra.Database.MySql.UnitOfWork
{
    public class UnitOfWork : UnitOfWorkBase<IDbContextConecta>, IUnitOfWork
    {
        public UnitOfWork(DbContextConecta context)
            : base(context)
        {
        }

        public Guid IdInstancia { get; set; } = Guid.NewGuid();
    }
}