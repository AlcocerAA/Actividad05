using Actividad05.DTOs;

namespace Actividad05.Services;

public interface IFormulaProduccionService
{
    Task<IEnumerable<FormulaProduccionResponseDto>> GetAllFormulas();
    Task<FormulaProduccionResponseDto?> GetFormulaById(int idProducto, int idMateriaPrima);
    Task<FormulaProduccionResponseDto> CreateFormula(FormulaProduccionCreateDto dto);
    Task<bool> UpdateFormula(int idProducto, int idMateriaPrima, FormulaProduccionUpdateDto dto);
    Task<bool> PatchFormula(int idProducto, int idMateriaPrima, FormulaProduccionUpdateDto dto);
    Task<bool> DeleteFormula(int idProducto, int idMateriaPrima);
}