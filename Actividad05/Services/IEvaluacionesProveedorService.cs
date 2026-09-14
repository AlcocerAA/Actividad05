using Actividad05.DTOs;

namespace Actividad05.Services;

public interface IEvaluacionesProveedorService
{
    Task<IEnumerable<EvaluacionesProveedorResponseDto>> GetAll();
    Task<EvaluacionesProveedorResponseDto?> GetById(int id);
    Task<EvaluacionesProveedorResponseDto> Create(EvaluacionesProveedorCreateUpdateDto dto);
    Task<bool> Update(int id, EvaluacionesProveedorCreateUpdateDto dto);
    Task<bool> Delete(int id);
}
