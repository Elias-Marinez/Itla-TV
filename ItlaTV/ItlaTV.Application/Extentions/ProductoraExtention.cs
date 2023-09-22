
using ItlaTV.Application.Dtos.Productora;
using ItlaTV.Domain.Entities;

namespace ItlaTV.Application.Extentions
{
    public static class ProductoraExtention
    {
        public static Productora ConvertToEntity(this ProductoraAddDto addDto)
        {
            return new Productora()
            {
                Nombre = addDto.Nombre
            };
        }
        public static Productora ConvertToEntity(this ProductoraUpdateDto updateDto)
        {
            return new Productora()
            {
                ProductoraId = updateDto.ProductoraId,
                Nombre = updateDto.Nombre
            };
        }
    }
}
