using Actividad05.Models;

namespace Actividad05.Services;

public interface IOrdenesProduccionService
{
    Task<IEnumerable<OrdenesProduccion>> GetAll();
    Task<OrdenesProduccion?> GetById(int id);
    Task<OrdenesProduccion> Create(OrdenesProduccion entity);
    Task<bool> Update(int id, OrdenesProduccion entity);
    Task<bool> Delete(int id);
}
