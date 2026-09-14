using Actividad05.Models;

namespace Actividad05.Services;

public interface IProveedoreService
{
    Task<IEnumerable<Proveedore>> GetAll();
    Task<Proveedore?> GetById(int id);
    Task<Proveedore> Create(Proveedore entity);
    Task<bool> Update(int id, Proveedore entity);
    Task<bool> Delete(int id);
}
