using Actividad05.DTOs;

namespace Actividad05.Services;

public interface IOrdenesProduccionService
{
    Task<IEnumerable<OrdenesProduccionResponseDto>> GetAll();
    Task<OrdenesProduccionResponseDto?> GetById(int id);
    Task<OrdenesProduccionResponseDto> Create(OrdenesProduccionCreateUpdateDto dto);
    Task<bool> Update(int id, OrdenesProduccionCreateUpdateDto dto);
    Task<bool> Delete(int id);
}
