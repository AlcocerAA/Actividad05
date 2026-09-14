using Actividad05.Models;

namespace Actividad05.Services;

public interface IMateriasPrimaService
{
    Task<IEnumerable<MateriasPrima>> GetAll();
    Task<MateriasPrima?> GetById(int id);
    Task<MateriasPrima> Create(MateriasPrima entity);
    Task<bool> Update(int id, MateriasPrima entity);
    Task<bool> Delete(int id);
}
