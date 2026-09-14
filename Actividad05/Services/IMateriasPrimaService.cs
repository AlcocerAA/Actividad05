using Actividad05.DTOs;

namespace Actividad05.Services;

public interface IMateriasPrimaService
{
    Task<IEnumerable<MateriasPrimaResponseDto>> GetAll();
    Task<MateriasPrimaResponseDto?> GetById(int id);
    Task<MateriasPrimaResponseDto> Create(MateriasPrimaCreateUpdateDto dto);
    Task<bool> Update(int id, MateriasPrimaCreateUpdateDto dto);
    Task<bool> Delete(int id);
}
