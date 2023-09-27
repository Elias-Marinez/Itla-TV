
using ItlaTV.Application.Contract;
using ItlaTV.Application.Service;
using ItlaTV.Infrastructure.Interfaces;
using ItlaTV.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace ItlaTV.IOC.Dependencies
{
    public static class SerieDependency
    {
        public static void AddSerieDependency(this IServiceCollection services)
        {
            services.AddScoped<ISerieRepository, SerieRepository>();
            services.AddTransient<ISerieService, SerieService>();
        }
    }
}
