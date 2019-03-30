using ControleDespesas.AppService;
using ControleDespesas.AppService.Interface;
using ControleDespesas.Infra.Data.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ControleDespesas.Infra.CrossCutting
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IDespesaAppService, DespesaAppService>();
            services.AddScoped<IDespesaRepository, DespesaRepository>();
        }
    }
}
