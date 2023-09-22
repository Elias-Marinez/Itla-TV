namespace ItlaTV.Domain.Entities
{
    public class Genero
    {
        public int GeneroId { get; set; }
        public required string Nombre { get; set; }

        //Navigation Property
        public ICollection<Serie>? Series { get; set; }
    }
}
