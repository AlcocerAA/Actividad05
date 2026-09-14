using Actividad05.Models;

namespace Actividad05.Services;

public interface IEvaluacionesProveedorService
{
    Task<IEnumerable<EvaluacionesProveedor>> GetAll();
    Task<EvaluacionesProveedor?> GetById(int id);
    Task<EvaluacionesProveedor> Create(EvaluacionesProveedor entity);
    Task<bool> Update(int id, EvaluacionesProveedor entity);
    Task<bool> Delete(int id);
}
