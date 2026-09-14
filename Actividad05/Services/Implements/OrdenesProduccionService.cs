using Actividad05.Models;
using Actividad05.Repositories;

namespace Actividad05.Services.Implements;

public class OrdenesProduccionService : IOrdenesProduccionService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdenesProduccionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<OrdenesProduccion>> GetAll()
    {
        return await _unitOfWork.OrdenesProduccion.GetAll();
    }

    public async Task<OrdenesProduccion?> GetById(int id)
    {
        return await _unitOfWork.OrdenesProduccion.GetById(id);
    }

    public async Task<OrdenesProduccion> Create(OrdenesProduccion entity)
    {
        await _unitOfWork.OrdenesProduccion.Add(entity);
        await _unitOfWork.SaveAsync();
        return entity;
    }

    public async Task<bool> Update(int id, OrdenesProduccion entity)
    {
        var existente = await _unitOfWork.OrdenesProduccion.GetById(id);
        if (existente == null) return false;

        existente.CantidadPlaneada = entity.CantidadPlaneada;
        existente.CantidadProducida = entity.CantidadProducida;
        existente.FechaPlanificada = entity.FechaPlanificada;
        existente.FechaInicio = entity.FechaInicio;
        existente.FechaEntrega = entity.FechaEntrega;
        existente.LineaProduccion = entity.LineaProduccion;
        existente.Responsable = entity.Responsable;

        _unitOfWork.OrdenesProduccion.Update(existente);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var existente = await _unitOfWork.OrdenesProduccion.GetById(id);
        if (existente == null) return false;

        await _unitOfWork.OrdenesProduccion.Delete(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
