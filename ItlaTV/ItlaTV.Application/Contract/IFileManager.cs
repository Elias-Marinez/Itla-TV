
using Microsoft.AspNetCore.Http;

namespace ItlaTV.Application.Contract
{
    public interface IFileManager
    {
        Task<string> SubirArchivoAsync(IFormFile archivo);
        Task<string> ActualizarArchivoAsync(IFormFile archivo, string imagePath);
        void EliminarArchivo(string imagePath);
    }
}
