
using ItlaTV.Application.Contract;
using ItlaTV.Application.Core;
using ItlaTV.Application.Dtos.Productora;
using ItlaTV.Application.Extentions;
using ItlaTV.Infrastructure.Interfaces;

namespace ItlaTV.Application.Service
{
    public class ProductoraService : IProductoraService
    {
        private readonly IProductoraRepository _repository;

        public ProductoraService(IProductoraRepository repository)
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
                result.Message = "Error obteniendo las productoras" + ex.ToString();
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
                result.Message = $"Error obteniendo la productora de id:{id}" + ex.ToString();
            }

            return result;
        }

        public async Task<ServiceResult> Save(ProductoraAddDto addDto)
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
                result.Message = $"Error añadiendo la productora de nombre: {addDto.Nombre}" + ex.ToString();
            }

            return result;
        }

        public async Task<ServiceResult> Update(ProductoraUpdateDto updateDto)
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
                result.Message = $"Error actualizando la productora de id: {updateDto.ProductoraId}" + ex.ToString();
            }

            return result;
        }

        public async Task<ServiceResult> Remove(ProductoraRemoveDto removeDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var entity = await _repository.GetEntity(removeDto.ProductoraId);
                await _repository.Remove(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error eliminando la productora de id: {removeDto.ProductoraId}" + ex.ToString();
            }

            return result;
        }
    }
}
