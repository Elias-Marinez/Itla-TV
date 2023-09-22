
using ItlaTV.Application.Contract;
using ItlaTV.Application.Core;
using ItlaTV.Application.Dtos.Genero;
using ItlaTV.Application.Extentions;
using ItlaTV.Infrastructure.Interfaces;

namespace ItlaTV.Application.Service
{
    public class GeneroService : IGeneroService
    {
        public readonly IGeneroRepository _repository;

        public GeneroService(IGeneroRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult> Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await _repository.GetEntities();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los generos" + ex.ToString();
            }

            return result;
        }

        public async Task<ServiceResult> GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await _repository.GetEntity(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo el genero de id: {id}" + ex.ToString();
            }

            return result;
        }
        public async Task<ServiceResult> Save(GeneroAddDto addDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var entity = addDto.ConvertToEntity();
                await _repository.Add(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error añadiendo el genero de nombre: {addDto.Nombre}" + ex.ToString();
            }

            return result;
        }

        public async Task<ServiceResult> Update(GeneroUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var entity = updateDto.ConvertToEntity();
                await _repository.Update(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error actualizando el genero de id: {updateDto.GeneroId}" + ex.ToString();
            }

            return result;
        }

        public async Task<ServiceResult> Remove(GeneroRemoveDto removeDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var entity = await _repository.GetEntity(removeDto.GeneroId);
                await _repository.Remove(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error eliminando el genero de id: {removeDto.GeneroId}" + ex.ToString();
            }

            return result;
        }
    }
}
