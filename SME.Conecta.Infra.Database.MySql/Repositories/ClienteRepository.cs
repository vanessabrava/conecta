using SME.Conecta.Infra.Database.MySql.Contexts;
using SME.Conecta.Infra.Database.Repositories;
using SME.Conecta.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Conecta.Infra.Database.MySql.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private DbContextConecta Context { get; }

        public ClienteRepository(DbContextConecta context) => Context = context;

        public void Novo(Cliente cliente) => Context.Cliente.Add(cliente);

        public void Alterar(Cliente pais) => Context.SetModified(pais);

    }
}
