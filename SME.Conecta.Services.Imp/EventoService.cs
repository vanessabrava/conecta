using SME.Conecta.Infra.CrossCutting.Model.ModelRules;
using SME.Conecta.Infra.Database.Repositories;
using SME.Conecta.Infra.Database.UnitOfWork;
using SME.Conecta.Services.Models;

namespace SME.Conecta.Services.Imp
{
    public class EventoService : IEventoService
    {
        private IUnitOfWork UnitOfWork { get; }

        private IClienteRepository ClienteRepository { get; }

        private static DateTime AbsoluteExpiration => DateTime.Now.AddMonths(1);

        public EventoService(IUnitOfWork unitOfWork, IClienteRepository clienteRepository)
        {
            UnitOfWork = unitOfWork;
            ClienteRepository = clienteRepository;
            
        }

        public ModelResult NovoEvento(string nome)
        {
            var result = new ModelResult();

            if (!result.EhModelResultValido())
                return result;


            var eventoResult = Cliente.Novo(nome);

            if (!eventoResult.EhModelResultValido())
                return eventoResult;

            ClienteRepository.Novo(eventoResult.Model);
            UnitOfWork.SaveChanges();



            return result;

        }

    }
}