using SME.Conecta.Infra.Database.MySql.Base;


namespace SME.Conecta.Infra.Database.Base
{
    public interface IDbContextFactory
    {
        IDbContext GetContext();
    }
}
