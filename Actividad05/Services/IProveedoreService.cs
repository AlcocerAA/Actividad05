using Actividad05.DTOs;

namespace Actividad05.Services;

public interface IProveedoreService
{
    Task<IEnumerable<ProveedoreResponseDto>> GetAll();
    Task<ProveedoreResponseDto?> GetById(int id);
    Task<ProveedoreResponseDto> Create(ProveedoreCreateUpdateDto dto);
    Task<bool> Update(int id, ProveedoreCreateUpdateDto dto);
    Task<bool> Delete(int id);
}
