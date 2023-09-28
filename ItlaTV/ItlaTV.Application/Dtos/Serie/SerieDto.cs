
using Microsoft.AspNetCore.Http;

namespace ItlaTV.Application.Dtos.Serie
{
    public abstract class SerieDto
    {
        public required string Nombre { get; set; }
        public IFormFile? Imagen { get; set; }
        public int ProductoraId { get; set; }
        public int GeneroId { get; set; }
        public int SGeneroId { get; set; }
        public required string Enlace { get; set; }
    }
}
