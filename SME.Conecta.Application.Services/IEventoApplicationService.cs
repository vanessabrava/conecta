using SME.Conecta.Application.Messages;
using SME.Conecta.Application.Messages.Base;

namespace SME.Conecta.Application.Services
{
    public interface IEventoApplicationService
    {
        ResultResponseMessage<ResponseMessage> NovoEvento(NovoClienteMessageRequest request);
    }
}