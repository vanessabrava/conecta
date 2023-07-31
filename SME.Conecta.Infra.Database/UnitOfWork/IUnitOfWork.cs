using SME.Conecta.Infra.Database.Base;
using SME.Conecta.Infra.Database.Contexts;

namespace SME.Conecta.Infra.Database.UnitOfWork
{
    public interface IUnitOfWork : IUnitOfWorkBase<IDbContextConecta>
    {
    }
}