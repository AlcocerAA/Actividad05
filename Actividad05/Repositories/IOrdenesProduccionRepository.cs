using Actividad05.Models;

namespace Actividad05.Repositories;

public interface IOrdenesProduccionRepository
{
    Task<IEnumerable<OrdenesProduccion>> GetAll();
    Task<OrdenesProduccion?> GetById(int id);
    Task Add(OrdenesProduccion entity);
    void Update(OrdenesProduccion entity);
    Task Delete(int id);
}
