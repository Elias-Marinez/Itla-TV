
using ItlaTV.Application.Contract;
using ItlaTV.Application.Service;
using ItlaTV.Infrastructure.Interfaces;
using ItlaTV.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ItlaTV.IOC.Dependencies
{
    public static class ProductoraDependency
    {
        public static void AddProductoraDependency(this IServiceCollection services)
        {
            services.AddScoped<IProductoraRepository, ProductoraRepository>();
            services.AddTransient<IProductoraService, ProductoraService>();
        }
    }
}
