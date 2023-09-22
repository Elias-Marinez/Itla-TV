
using ItlaTV.Application.Dtos.Genero;
using ItlaTV.Domain.Entities;

namespace ItlaTV.Application.Extentions
{
    public static class GeneroExtention
    {
        public static Genero ConvertToEntity(this GeneroAddDto addDto)
        {
            return new Genero()
            {
                Nombre = addDto.Nombre
            };
        }
        public static Genero ConvertToEntity(this GeneroUpdateDto updateDto)
        {
            return new Genero()
            {
                GeneroId = updateDto.GeneroId,
                Nombre = updateDto.Nombre
            };
        }
    }
}
