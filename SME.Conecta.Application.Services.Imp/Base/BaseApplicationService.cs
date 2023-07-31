using SME.Conecta.Application.Messages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SME.Conecta.Application.Services.Imp.Base
{
    public abstract class BaseApplicationService
    {
        protected ResultResponseMessage<TResponse> MapResultResponseFromModelResult<TResponse>(ResultResponseMessage<TResponse> result, ModelResult modelResult)
           where TResponse : ResponseMessage
        {
            if (!modelResult.EhModelResultValido())
            {
                //var validacoes = new List<ValidationMessage>();

                //if (modelResult.Validacoes != null)
                //{
                 //   foreach (var item in modelResult.Validacoes)
                   // {
                     //   validacoes.Add(new ValidationMessage() { Atributo = item.Atributo, Mensagem = item.Mensagem });
                    //}
                //}

                result.MapResultResponseMessage((HttpStatusCode)modelResult.CodigoMensagem, modelResult.Mensagem);

               
                    result.CreateResponseBadRequest("Campos");

                return result;
            }

            return result;
        }
    }
}
