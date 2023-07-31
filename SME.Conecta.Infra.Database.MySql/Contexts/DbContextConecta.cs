using SME.Conecta.Infra.Database.Base;
using SME.Conecta.Services.Models;
using Microsoft.EntityFrameworkCore;
using SME.Conecta.Infra.Database.MySql.Base;
using SME.Conecta.Infra.Database.Contexts;
using SME.Conecta.Infra.Database.MySql.Mappings;

namespace SME.Conecta.Infra.Database.MySql.Contexts
{
    public class DbContextConecta : DbContextBase, IDbContextConecta
    {
        public DbContextConecta(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity(ClienteMapConfig.ConfigureMap());

        }
    }
}
