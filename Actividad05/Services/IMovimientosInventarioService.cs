using Actividad05.Models;

namespace Actividad05.Services;

public interface IMovimientosInventarioService
{
    Task<IEnumerable<MovimientosInventario>> GetAll();
    Task<MovimientosInventario?> GetById(int id);
    Task<MovimientosInventario> Create(MovimientosInventario entity);
    Task<bool> Update(int id, MovimientosInventario entity);
    Task<bool> Delete(int id);
}
