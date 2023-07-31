using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SME.Conecta.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Conecta.Infra.Database.MySql.Mappings
{
    internal class ClienteMapConfig
    {
        internal static Action<EntityTypeBuilder<Cliente>> ConfigureMap()
        {
            return (entity) =>
            {
                entity.ToTable("Cliente");

                entity.HasKey(it => it.IdCliente);

                entity.Property(it => it.IdCliente)
                    .HasColumnName("IdCliente")
                    .IsRequired();

                entity.Property(it => it.Nome)
                    .HasColumnName("Nome")
                    .HasMaxLength(150)
                    .IsRequired();
            };
        }
    }
}
