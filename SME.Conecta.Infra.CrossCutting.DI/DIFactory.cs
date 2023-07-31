using SME.Conecta.Infra.Database.Contexts;
using SME.Conecta.Infra.Database.MySql.Contexts;
using SME.Conecta.Infra.Database.MySql.UnitOfWork;
using SME.Conecta.Infra.Database.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SME.Conecta.Infra.CrossCutting.DI
{
    public static class DIFactory
    {
        public static void ConfigureDI(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbContextConecta, DbContextConecta>();
            //services.AddScoped<IRabitMQService, RabitMQRService>();
            //services.AddScoped<IEventoRepository, EventoRepository>();
            

           
        }
    }
}