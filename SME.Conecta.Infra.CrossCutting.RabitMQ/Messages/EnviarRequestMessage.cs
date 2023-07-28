using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Conecta.Infra.CrossCutting.RabitMQ.Messages
{
    public  class EnviarRequestMessage
    {
        public string Id { get; set; }

        public string Mensagem { get; set; }
    }
}
