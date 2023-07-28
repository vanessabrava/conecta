using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Conecta.Infra.CrossCutting.Model.ModelRules
{
    public class Validation
    {
        public string Atributo { get; private set; }

        public string Mensagem { get; private set; }

        private Validation() { }

        public Validation(string atributo, string mensagem)
            : this()
        {
            Atributo = atributo;
            Mensagem = mensagem;
        }
    }
}
