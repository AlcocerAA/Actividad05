using Actividad05.Models;

namespace Actividad05.Repositories;

public interface IMovimientosInventarioRepository
{
    Task<IEnumerable<MovimientosInventario>> GetAll();
    Task<MovimientosInventario?> GetById(int id);
    Task Add(MovimientosInventario entity);
    void Update(MovimientosInventario entity);
    Task Delete(int id);
}
