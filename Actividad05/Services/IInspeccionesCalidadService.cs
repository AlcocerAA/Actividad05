using Actividad05.Models;

namespace Actividad05.Services;

public interface IInspeccionesCalidadService
{
    Task<IEnumerable<InspeccionesCalidad>> GetAll();
    Task<InspeccionesCalidad?> GetById(int id);
    Task<InspeccionesCalidad> Create(InspeccionesCalidad entity);
    Task<bool> Update(int id, InspeccionesCalidad entity);
    Task<bool> Delete(int id);
}
