
using ItlaTV.Application.Dtos.Serie;
using ItlaTV.Domain.Entities;

namespace ItlaTV.Application.Extentions
{
    public static class SerieExtention
    {
        public static Serie ConvertToEntity(this SerieAddDto addDto)
        {
            return new Serie()
            {
                Nombre = addDto.Nombre,
                ImagePath = addDto.ImagePath,
                ProductoraId = addDto.ProductoraId,
                GeneroId = addDto.GeneroId,
                SGeneroId = addDto.SGeneroId,
                Enlace = addDto.Enlace
            };
        }
        public static Serie ConvertToEntity(this SerieUpdateDto updateDto)
        {
            return new Serie()
            {
                SerieId = updateDto.SerieId,
                Nombre = updateDto.Nombre,
                ImagePath = updateDto.ImagePath,
                ProductoraId = updateDto.ProductoraId,
                GeneroId = updateDto.GeneroId,
                SGeneroId = updateDto.SGeneroId,
                Enlace = updateDto.Enlace
            };
        }
    }
}
