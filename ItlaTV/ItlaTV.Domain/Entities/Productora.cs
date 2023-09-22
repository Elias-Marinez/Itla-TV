namespace ItlaTV.Domain.Entities
{
    public class Productora
    {
        public int ProductoraId { get; set; }
        public required string Nombre { get; set; }

        //Navigation Property
        public ICollection<Serie>? Series {  get; set; }
    }
}
