using ItlaTV.Web.Models.Genero;
using ItlaTV.Web.Models.Productora;
using System.ComponentModel.DataAnnotations;

namespace ItlaTV.Web.Models.Serie
{
    public class SerieUpdateViewModel
    {
        public int SerieId { get; set; }
        public required string ImagenPath { get; set; }
        public IFormFile? Imagen { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo ProductoraId es requerido.")]
        public int ProductoraId { get; set; }

        [Required(ErrorMessage = "El campo GeneroId es requerido.")]
        public int GeneroId { get; set; }

        [Required(ErrorMessage = "El campo SGeneroId es requerido.")]
        public int SGeneroId { get; set; }

        [Required(ErrorMessage = "El campo Enlace es requerido.")]
        public string Enlace { get; set; }

        public IEnumerable<GeneroViewModel>? Generos { get; set; }
        public IEnumerable<ProductoraViewModel>? Productoras { get; set; }
    }
}
