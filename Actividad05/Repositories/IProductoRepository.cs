using Actividad05.Models;

namespace Actividad05.Repositories;

public interface IProductoRepository
{
    Task<IEnumerable<Producto>> GetAll();
    Task<Producto?> GetById(int id);
    Task Add(Producto entity);
    void Update(Producto entity);
    Task Delete(int id);
}
