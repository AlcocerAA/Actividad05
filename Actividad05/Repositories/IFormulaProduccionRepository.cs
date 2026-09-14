using Actividad05.Models;

namespace Actividad05.Repositories;

public interface IFormulaProduccionRepository
{
    Task<IEnumerable<FormulaProduccion>> GetAll();
    Task<FormulaProduccion?> GetById(int idProducto, int idMateriaPrima);
    Task Add(FormulaProduccion formula);
    void Update(FormulaProduccion formula);
    Task Delete(int idProducto, int idMateriaPrima);
}