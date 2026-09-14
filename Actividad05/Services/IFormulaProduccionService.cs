using Actividad05.Models;

namespace Actividad05.Services;

public interface IFormulaProduccionService
{
    Task<IEnumerable<FormulaProduccion>> GetAllFormulas();
    Task<FormulaProduccion?> GetFormulaById(int idProducto, int idMateriaPrima);
    Task<FormulaProduccion> CreateFormula(FormulaProduccion formula);
    Task<bool> UpdateFormula(int idProducto, int idMateriaPrima, FormulaProduccion formula);
    Task<bool> PatchFormula(int idProducto, int idMateriaPrima, FormulaProduccion formula);
    Task<bool> DeleteFormula(int idProducto, int idMateriaPrima);
}