using Actividad05.Models;
using Actividad05.Repositories;

namespace Actividad05.Services.Implements;

public class EvaluacionesProveedorService : IEvaluacionesProveedorService
{
    private readonly IUnitOfWork _unitOfWork;

    public EvaluacionesProveedorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<EvaluacionesProveedor>> GetAll()
    {
        return await _unitOfWork.EvaluacionesProveedores.GetAll();
    }

    public async Task<EvaluacionesProveedor?> GetById(int id)
    {
        return await _unitOfWork.EvaluacionesProveedores.GetById(id);
    }

    public async Task<EvaluacionesProveedor> Create(EvaluacionesProveedor entity)
    {
        await _unitOfWork.EvaluacionesProveedores.Add(entity);
        await _unitOfWork.SaveAsync();
        return entity;
    }

    public async Task<bool> Update(int id, EvaluacionesProveedor entity)
    {
        var existente = await _unitOfWork.EvaluacionesProveedores.GetById(id);
        if (existente == null) return false;

        existente.CalidadInsumo = entity.CalidadInsumo;
        existente.PrecioCompetitivo = entity.PrecioCompetitivo;
        existente.Puntualidad = entity.Puntualidad;
        existente.Observaciones = entity.Observaciones;

        _unitOfWork.EvaluacionesProveedores.Update(existente);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var existente = await _unitOfWork.EvaluacionesProveedores.GetById(id);
        if (existente == null) return false;

        await _unitOfWork.EvaluacionesProveedores.Delete(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
