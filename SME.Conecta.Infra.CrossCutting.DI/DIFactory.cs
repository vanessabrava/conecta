using SME.Conecta.Application.Services;
using SME.Conecta.Application.Services.Imp;
using SME.Conecta.Infra.CrossCutting.RabitMQ.Abstracts;
using SME.Conecta.Infra.CrossCutting.RabitMQ.Concrets;
using SME.Conecta.Infra.Database.Contexts;
using SME.Conecta.Infra.Database.MySql.Contexts;
using SME.Conecta.Infra.Database.MySql.Repositories;
using SME.Conecta.Infra.Database.MySql.UnitOfWork;
using SME.Conecta.Infra.Database.Repositories;
using SME.Conecta.Infra.Database.UnitOfWork;
using SME.Conecta.Services;
using SME.Conecta.Services.Imp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SME.Conecta.Infra.CrossCutting.DI
{
    public static class DIFactory
    {
        public static void ConfigureDI(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbContextDesafioRadix, DbContextDesafioRadix>();

            services.AddScoped<ISignalRService, SignalRService>();

            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IPaisRepository, PaisRepository>();
            services.AddScoped<IRegiaoRepository, RegiaoRepository>();
            services.AddScoped<ISensorRepository, SensorRepository>();

            services.AddScoped<IEventoService, EventoService>();

            services.AddScoped<IEventoApplicationService, EventoApplicationService>();
        }
    }
}