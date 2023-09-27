
using ItlaTV.Application.Contract;
using ItlaTV.Application.Service;
using ItlaTV.Infrastructure.Interfaces;
using ItlaTV.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ItlaTV.IOC.Dependencies
{
    public static class GeneroDependency
    {
        public static void AddGeneroDependency(this IServiceCollection services)
        {
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddTransient<IGeneroService, GeneroService>();
        }
    }
}
