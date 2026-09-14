using Actividad05.Models;

namespace Actividad05.Services;

public interface IProductoService
{
    Task<IEnumerable<Producto>> GetAll();
    Task<Producto?> GetById(int id);
    Task<Producto> Create(Producto entity);
    Task<bool> Update(int id, Producto entity);
    Task<bool> Delete(int id);
}
