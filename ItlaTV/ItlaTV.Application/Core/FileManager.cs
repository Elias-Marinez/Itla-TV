using ItlaTV.Application.Contract;
using Microsoft.AspNetCore.Http;

namespace ItlaTV.Application.Core
{
    public class FileManager : IFileManager
    {
        private string ruta = "wwwroot/imagenes/series";
        public async Task<string> SubirArchivoAsync(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                throw new ArgumentException("El archivo no es válido.");
            }

            // Generar un nombre de archivo único
            var nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(archivo.FileName);

            // Ruta donde se guardarán las imágenes en el sistema de archivos
            var rutaImagen = Path.Combine(Directory.GetCurrentDirectory(), this.ruta, nombreArchivo);

            using (var stream = new FileStream(rutaImagen, FileMode.Create))
            {
                await archivo.CopyToAsync(stream);
            }

            return nombreArchivo;
        }
        public async Task<string> ActualizarArchivoAsync(IFormFile archivo, string imagePath)
        {
            EliminarArchivo(imagePath);

            return await SubirArchivoAsync(archivo);
        }

        public void EliminarArchivo(string imagePath)
        {
            string rutaImagen = this.ruta + "/" + imagePath;

            if (File.Exists(rutaImagen))
            {
                File.Delete(rutaImagen);
            }
        }
    }
}