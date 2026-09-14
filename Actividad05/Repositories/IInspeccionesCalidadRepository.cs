using Actividad05.Models;

namespace Actividad05.Repositories;

public interface IInspeccionesCalidadRepository
{
    Task<IEnumerable<InspeccionesCalidad>> GetAll();
    Task<InspeccionesCalidad?> GetById(int id);
    Task Add(InspeccionesCalidad entity);
    void Update(InspeccionesCalidad entity);
    Task Delete(int id);
}
