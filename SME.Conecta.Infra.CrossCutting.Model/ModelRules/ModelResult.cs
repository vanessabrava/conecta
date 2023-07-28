using SME.Conecta.Infra.CrossCutting.Common.Constantes;
using System.Collections.Generic;
using System.Linq;

namespace SME.Conecta.Infra.CrossCutting.Model.ModelRules
{
    public class ModelResult
    {
        public IEnumerable<Validation> Validacoes { get; private set; } = new List<Validation>();

        public int CodigoMensagem { get; private set; }

        public string Mensagem { get; private set; }

        public ModelResult() => CriarOk();

        public void CriarMensagemNegocio(string mensagem)
        {
            Mensagem = mensagem;
            CodigoMensagem = 422;
        }

        public void CriarErroCustomizado(string mensagem = null)
        {
            Mensagem = string.IsNullOrWhiteSpace(mensagem) ? ConstMessages.MsgErrorDefault : mensagem;
            CodigoMensagem = 500;
        }

        public void CriarOk()
        {
            Mensagem = "Sucesso.";
            CodigoMensagem = 200;
        }

        public void AdicionarValidacao(string atributo, string mensagem)
        {
            Validacoes = Validacoes.Concat(new[] { new Validation(atributo, mensagem) });
            CriarMensagemValidacaoCampos();
        }

        public bool EhModelResultValido() => CodigoMensagem < 400;

        private void CriarMensagemValidacaoCampos()
        {
            Mensagem = "Validação de Campos.";
            CodigoMensagem = 400;
        }
    }

    public class ModelResult<TModel> : ModelResult where TModel : IEntity
    {
        public ModelResult()
            : base()
        {
        }

        public TModel Model { get; private set; }

        public void SetModel(TModel model) => Model = model;
    }
}
