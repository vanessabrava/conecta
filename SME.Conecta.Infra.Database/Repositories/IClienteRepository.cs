using SME.Conecta.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Conecta.Infra.Database.Repositories
{
    public interface IClienteRepository
    {
        void Novo(Cliente cliente);

        void Alterar(Cliente cliente);
    }
}
