using Actividad05.Models;

namespace Actividad05.Repositories;

public interface IEvaluacionesProveedorRepository
{
    Task<IEnumerable<EvaluacionesProveedor>> GetAll();
    Task<EvaluacionesProveedor?> GetById(int id);
    Task Add(EvaluacionesProveedor entity);
    void Update(EvaluacionesProveedor entity);
    Task Delete(int id);
}
