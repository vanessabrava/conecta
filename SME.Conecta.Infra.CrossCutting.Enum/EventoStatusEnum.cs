using System.ComponentModel;
namespace SME.Conecta.Infra.CrossCutting.Enum
{
    public enum EventoStatusEnum
    {
        [Description("Processado")]
        Processado = 1,
        [Description("Erro")]
        Erro = 2
    }
}