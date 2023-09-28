namespace ItlaTV.Web.Models.Serie
{
    public class SerieViewModel
    {
        public int SerieId { get; set; }
        public required string Nombre { get; set; }
        public required string ImagePath { get; set; }
        public required string NombreProductora { get; set; }
        public required string NGenero { get; set; }
        public required string SNGenero { get; set; }
        public string? Enlace { get; set; }
    }
}
