using SME.Conecta.Application.Messages.Base;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SME.Conecta.Application.Messages
{
    [DataContract(Namespace = "http://www.sme.com.br/types/")]
    public class NovoClienteMessageRequest : BaseRequestMessage
    {
        [DataMember(Name = "Nome"), Required(ErrorMessage = "O nome  é obrigatório.")]
        public string Nome { get; set; }

    }
}