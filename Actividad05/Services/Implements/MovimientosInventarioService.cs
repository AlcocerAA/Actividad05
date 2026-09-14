using Actividad05.Models;
using Actividad05.Repositories;

namespace Actividad05.Services.Implements;

public class MovimientosInventarioService : IMovimientosInventarioService
{
    private readonly IUnitOfWork _unitOfWork;

    public MovimientosInventarioService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<MovimientosInventario>> GetAll()
    {
        return await _unitOfWork.MovimientosInventario.GetAll();
    }

    public async Task<MovimientosInventario?> GetById(int id)
    {
        return await _unitOfWork.MovimientosInventario.GetById(id);
    }

    public async Task<MovimientosInventario> Create(MovimientosInventario entity)
    {
        await _unitOfWork.MovimientosInventario.Add(entity);
        await _unitOfWork.SaveAsync();
        return entity;
    }

    public async Task<bool> Update(int id, MovimientosInventario entity)
    {
        var existente = await _unitOfWork.MovimientosInventario.GetById(id);
        if (existente == null) return false;

        existente.Cantidad = entity.Cantidad;
        existente.Responsable = entity.Responsable;
        existente.IdMateriaPrima = entity.IdMateriaPrima;
        existente.IdProducto = entity.IdProducto;
        existente.IdOrden = entity.IdOrden;

        _unitOfWork.MovimientosInventario.Update(existente);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var existente = await _unitOfWork.MovimientosInventario.GetById(id);
        if (existente == null) return false;

        await _unitOfWork.MovimientosInventario.Delete(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
