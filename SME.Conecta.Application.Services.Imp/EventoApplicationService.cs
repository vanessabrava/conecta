using SME.Conecta.Application.Messages;
using SME.Conecta.Application.Messages.Base;
using SME.Conecta.Application.Services.Imp.Base;
using SME.Conecta.Services;

namespace SME.Conecta.Application.Services.Imp
{
    public class EventoApplicationService : BaseApplicationService, IEventoApplicationService
    {
        private IEventoService EventoService { get; }

        public EventoApplicationService(IEventoService eventoService) => EventoService = eventoService;

        public ResultResponseMessage<ResponseMessage> NovoEvento(NovoClienteMessageRequest request)
        {
            var resultResponse = new ResultResponseMessage<ResponseMessage>(request);

            var modelResult = EventoService.NovoEvento(request.Nome);


            return MapResultResponseFromModelResult(resultResponse, modelResult);

        }
    }
}