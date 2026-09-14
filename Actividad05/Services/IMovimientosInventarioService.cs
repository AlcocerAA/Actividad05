using Actividad05.DTOs;

namespace Actividad05.Services;

public interface IMovimientosInventarioService
{
    Task<IEnumerable<MovimientosInventarioResponseDto>> GetAll();
    Task<MovimientosInventarioResponseDto?> GetById(int id);
    Task<MovimientosInventarioResponseDto> Create(MovimientosInventarioCreateUpdateDto dto);
    Task<bool> Update(int id, MovimientosInventarioCreateUpdateDto dto);
    Task<bool> Delete(int id);
}
