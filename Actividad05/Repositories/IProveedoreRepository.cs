using Actividad05.Models;

namespace Actividad05.Repositories;

public interface IProveedoreRepository
{
    Task<IEnumerable<Proveedore>> GetAll();
    Task<Proveedore?> GetById(int id);
    Task Add(Proveedore entity);
    void Update(Proveedore entity);
    Task Delete(int id);
}
