using SME.Conecta.Infra.Database.Base;
using SME.Conecta.Services.Models;
using Microsoft.EntityFrameworkCore;
using SME.Conecta.Infra.Database.MySql.Base;

namespace SME.Conecta.Infra.Database.Contexts
{
    public interface IDbContextConecta : IDbContext
    {
        DbSet<Cliente> Cliente { get; }

       
    }
}
