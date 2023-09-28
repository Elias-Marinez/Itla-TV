using ItlaTV.Application.Contract;
using ItlaTV.Application.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ItlaTV.IOC.Dependencies
{
    public static class FileManagerDependency
    {
        public static void AddFileManagerDependency(this IServiceCollection services)
        {
            services.AddTransient<IFileManager, FileManager>();
        }
    }
}
