using Microsoft.Extensions.DependencyInjection;
using PDV.Dominio;
using PDV.Dominio.ValorMonetario;
using PDV.Dominio.Venda;
using PDV.Infra;
using PDV.Infra.Context;
using PDV.Infra.Repository;
using PDV.Servico.Services;

namespace PDV.Ioc
{
    public class InjecaoDeDependencia
    {
        public static void RegisterServices(IServiceCollection services)
        {            
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IValorRepository, ValorRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<PdvContext>();
        }
    }
}
