using Easynvest.Test.Application.Interfaces;
using Easynvest.Test.Application.Notificacoes;
using Easynvest.Test.Application.Services;
using Easynvest.Test.Infra.Context;
using Easynvest.Test.Infra.Interfaces;
using Easynvest.Test.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Easynvest.Test.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IOrdemCompraRepository, OrdemCompraRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IOrdemCompraService, OrdemCompraService>();

            return services;
        }
    }
}
