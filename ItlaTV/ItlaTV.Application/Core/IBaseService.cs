
namespace ItlaTV.Application.Core
{
    public interface IBaseService<AddDto, UpdateDto, RemoveDto> 
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int id);
        Task<ServiceResult> Save(AddDto addDto);
        Task<ServiceResult> Update(UpdateDto updateDto);
        Task<ServiceResult> Remove(RemoveDto removeDto);
    }
}
