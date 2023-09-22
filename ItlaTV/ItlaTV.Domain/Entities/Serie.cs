namespace ItlaTV.Domain.Entities
{
    public class Serie
    {
        public int SerieId { get; set; }
        public required string Nombre { get; set; }
        public required string ImagePath { get; set;}
        public int ProductoraId { get; set; }
        public int GeneroId { get; set; }
        public int SGeneroId { get; set; }
        public required string Enlace { get; set; }

        //Navigation Property
        public Productora? Productora { get; set; }
        public Genero? Genero { get; set; }
        public Genero? SGenero { get; set; }
    }
}
