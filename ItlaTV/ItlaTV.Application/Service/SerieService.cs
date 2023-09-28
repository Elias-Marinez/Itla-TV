
using ItlaTV.Application.Contract;
using ItlaTV.Application.Core;
using ItlaTV.Application.Dtos.Serie;
using ItlaTV.Application.Extentions;
using ItlaTV.Domain.Entities;
using ItlaTV.Infrastructure.Interfaces;
using System.Linq.Expressions;

namespace ItlaTV.Application.Service
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _repository;
        private readonly IFileManager _fileManager;

        public SerieService(ISerieRepository repository,
                            IFileManager fileManager)
        {
            _repository = repository;
            _fileManager = fileManager;
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
                result.Message = "Error obteniendo las series" + ex.ToString();
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
                result.Message = $"Error obteniendo la serie de id: {id}" + ex.ToString();
            }

            return result;
        }

        public async Task<ServiceResult> Save(SerieAddDto addDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                string imageNombre = await _fileManager.SubirArchivoAsync(addDto.Imagen);

                var entity = addDto.ConvertToEntity(imageNombre);
                await _repository.Add(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error añadiendo la serie de nombre: {addDto.Nombre}" + ex.ToString();
            }

            return result;
        }

        public async Task<ServiceResult> Update(SerieUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (updateDto.Imagen == null || updateDto.Imagen.Length == 0)
                {
                   var entity = updateDto.ConvertToEntity();
                   await _repository.Update(entity);
                }
                else
                {
                    string imageNombre = await _fileManager.ActualizarArchivoAsync(updateDto.Imagen, updateDto.ImagenPath);

                    var entity = updateDto.ConvertToEntity(imageNombre);
                    await _repository.Update(entity);
                }

                
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error actualizando la serie de id: {updateDto.SerieId}" + ex.ToString();
            }

            return result;
        }

        public async Task<ServiceResult> Remove(SerieRemoveDto removeDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var entity = await _repository.GetEntity(removeDto.SerieId);

                _fileManager.EliminarArchivo(entity.ImagePath);
                await _repository.Remove(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error eliminando la serie de id: {removeDto.SerieId}" + ex.ToString();
            }

            return result;
        }
    }
}
