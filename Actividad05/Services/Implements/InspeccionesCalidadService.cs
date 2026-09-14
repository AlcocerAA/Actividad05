using Actividad05.Models;
using Actividad05.Repositories;

namespace Actividad05.Services.Implements;

public class InspeccionesCalidadService : IInspeccionesCalidadService
{
    private readonly IUnitOfWork _unitOfWork;

    public InspeccionesCalidadService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<InspeccionesCalidad>> GetAll()
    {
        return await _unitOfWork.InspeccionesCalidad.GetAll();
    }

    public async Task<InspeccionesCalidad?> GetById(int id)
    {
        return await _unitOfWork.InspeccionesCalidad.GetById(id);
    }

    public async Task<InspeccionesCalidad> Create(InspeccionesCalidad entity)
    {
        await _unitOfWork.InspeccionesCalidad.Add(entity);
        await _unitOfWork.SaveAsync();
        return entity;
    }

    public async Task<bool> Update(int id, InspeccionesCalidad entity)
    {
        var existente = await _unitOfWork.InspeccionesCalidad.GetById(id);
        if (existente == null) return false;

        existente.Etapa = entity.Etapa;
        existente.CantidadInspeccionada = entity.CantidadInspeccionada;
        existente.CantidadDefectuosa = entity.CantidadDefectuosa;
        existente.Inspector = entity.Inspector;
        existente.Observaciones = entity.Observaciones;

        _unitOfWork.InspeccionesCalidad.Update(existente);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var existente = await _unitOfWork.InspeccionesCalidad.GetById(id);
        if (existente == null) return false;

        await _unitOfWork.InspeccionesCalidad.Delete(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
