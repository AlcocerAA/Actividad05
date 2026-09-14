using Actividad05.DTOs;

namespace Actividad05.Services;

public interface IInspeccionesCalidadService
{
    Task<IEnumerable<InspeccionesCalidadResponseDto>> GetAll();
    Task<InspeccionesCalidadResponseDto?> GetById(int id);
    Task<InspeccionesCalidadResponseDto> Create(InspeccionesCalidadCreateUpdateDto dto);
    Task<bool> Update(int id, InspeccionesCalidadCreateUpdateDto dto);
    Task<bool> Delete(int id);
}
