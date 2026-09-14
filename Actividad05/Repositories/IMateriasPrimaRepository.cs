using Actividad05.Models;

namespace Actividad05.Repositories;

public interface IMateriasPrimaRepository
{
    Task<IEnumerable<MateriasPrima>> GetAll();
    Task<MateriasPrima?> GetById(int id);
    Task Add(MateriasPrima entity);
    void Update(MateriasPrima entity);
    Task Delete(int id);
}
