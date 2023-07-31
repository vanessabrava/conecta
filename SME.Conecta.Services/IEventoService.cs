using SME.Conecta.Infra.CrossCutting.Model.ModelRules;

namespace SME.Conecta.Services
{
    public interface IEventoService
    {
        ModelResult NovoEvento(string nome);

    }
}