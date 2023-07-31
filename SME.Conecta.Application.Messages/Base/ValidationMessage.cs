using Microsoft.AspNetCore.Mvc;
using SME.Conecta.Infra.CrossCutting.Common.Constantes;

using System.Net;
using System.Runtime.Serialization;


namespace SME.Conecta.Application.Messages.Base
{
    [DataContract(Namespace = "http://www.sme.com.br/types/")]
    public class ResultResponseMessage<TResponseMessage> : IActionResult where TResponseMessage : ResponseMessage
    {
        public ResultResponseMessage() => CreateResponseOk();

        public ResultResponseMessage(BaseRequestMessage requestMessage) : this() => SetRequestMessage(requestMessage);

        [DataMember(Name = "response")]
        public TResponseMessage Response { get; set; }

        [DataMember(Name = "mensagem")]
        public string Mensagem { get; set; }

        [DataMember(Name = "protocolo")]
        public Guid Protocolo { get; private set; }

        public HttpStatusCode HttpStatusCode { get; private set; }

        public void SetRequestMessage(BaseRequestMessage requestMessage)
        {
            if (requestMessage == null)
                throw new ArgumentNullException("O requestMessage não pode ser nulo.");

            if (!Guid.TryParse(requestMessage.GetHeader(ConstHeaders.Protocolo), out Guid protocolo))
                throw new ArgumentException("Protocolo inválido requestMessage.");

            Protocolo = protocolo;
        }

        public ResultResponseMessage<TNewResponseMessage> GetNewResultMessage<TNewResponseMessage>(BaseRequestMessage requestMessage)
            where TNewResponseMessage : ResponseMessage => new ResultResponseMessage<TNewResponseMessage>(requestMessage)
            {
                Protocolo = Protocolo,
                HttpStatusCode = HttpStatusCode,
                Mensagem = Mensagem,
                
            };

        public void MapResultResponseMessage(HttpStatusCode httpStatusCode, string mensagem = null, Guid? protocolo = null)
        {
            if (protocolo.HasValue)
                Protocolo = protocolo.Value;

           
            CreateResponseToHttpStatusCode(httpStatusCode, mensagem);
        }

        public void MapResultResponseMessageFromAnotherResult<TAnotherResponseMessage>(ResultResponseMessage<TAnotherResponseMessage> outroResult)
            where TAnotherResponseMessage : ResponseMessage
        {
            if (outroResult.Protocolo != Guid.Empty)
                Protocolo = outroResult.Protocolo;

            
            CreateResponseToHttpStatusCode(outroResult.HttpStatusCode, outroResult.Mensagem);
        }

      
        public bool EhHttpStatusCodeError()
        {
            int errorCode = (int)HttpStatusCode;
            return errorCode >= 400;
        }

        #region Padrões de respostas Http

        public void CreateResponseUnprocessableEntity(string mensagem)
        {
            Mensagem = (string.IsNullOrWhiteSpace(mensagem) ? "Validação" : mensagem);
            HttpStatusCode = (HttpStatusCode)422;
        }

        public void CreateResponseOk()
        {
            Mensagem = "Sucesso.";
            HttpStatusCode = (HttpStatusCode)200;
        }

        public void CreateResponseCreated()
        {
            Mensagem = "Criado com sucesso.";
            HttpStatusCode = (HttpStatusCode)201;
        }

        public void CreateResponseAccepted()
        {
            Mensagem = "Adicionado na fila.";
            HttpStatusCode = (HttpStatusCode)202;
        }

        public void CreateResponseBadRequest(string message)
        {
            Mensagem = (string.IsNullOrWhiteSpace(message) ? "Validação" : message);
            HttpStatusCode = (HttpStatusCode)400;
        }

        public void CreateResponseInternalServerError(string mensagem = null)
        {
            Mensagem = string.IsNullOrWhiteSpace(mensagem) ? ConstMessages.MsgErrorDefault : mensagem;
            HttpStatusCode = (HttpStatusCode)500;
        }

        public void CreateResponseForbidden()
        {
            Mensagem = "O servidor recusou a requisição.";
            HttpStatusCode = (HttpStatusCode)403;
        }

        public void CreateResponseNotFound()
        {
            Mensagem = "Recurso não encontrado no servidor.";
            HttpStatusCode = (HttpStatusCode)404;
        }

        public void CreateResponseServiceUnavailable(string mensagem = "Serviço indisponível.")
        {
            Mensagem = mensagem;
            HttpStatusCode = (HttpStatusCode)503;
        }

        public void CreateResponseUnauthorized(string message = "Não autorizado o acesso ao recurso.")
        {
            Mensagem = message;
            HttpStatusCode = (HttpStatusCode)401;
        }

        public void CreateResponseNotAcceptable()
        {
            Mensagem = "Informações no header não informado.";
            HttpStatusCode = (HttpStatusCode)406;
        }

        public void CreateResponseRequestTimeout(string mensagem = "Timeout no request.")
        {
            Mensagem = mensagem;
            HttpStatusCode = HttpStatusCode.RequestTimeout;
        }

        public void CreateResponseGatewayTimeout(string mensagem = "Timeout.")
        {
            Mensagem = mensagem;
            HttpStatusCode = HttpStatusCode.GatewayTimeout;
        }

        #endregion Padrões de respostas Http

        private void CreateResponseToHttpStatusCode(HttpStatusCode httpStatusCode, string message)
        {
            switch ((int)httpStatusCode)
            {
                case 422:
                    CreateResponseUnprocessableEntity(message);
                    break;
                case 200:
                    CreateResponseOk();
                    break;
                case 201:
                    CreateResponseCreated();
                    break;
                case 202:
                    CreateResponseAccepted();
                    break;
                case 400:
                    CreateResponseBadRequest(message);
                    break;
                case 500:
                    CreateResponseInternalServerError(message);
                    break;
                case 403:
                    CreateResponseForbidden();
                    break;
                case 404:
                    CreateResponseNotFound();
                    break;
                case 503:
                    CreateResponseServiceUnavailable(message);
                    break;
                case 401:
                    CreateResponseUnauthorized(message);
                    break;
                case 406:
                    CreateResponseNotAcceptable();
                    break;
                case 408:
                    CreateResponseRequestTimeout();
                    break;
                case 504:
                    CreateResponseGatewayTimeout();
                    break;
                default:
                    CreateResponseInternalServerError(message);
                    break;
            }
        }

        async Task IActionResult.ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(this) { StatusCode = (int)HttpStatusCode };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}