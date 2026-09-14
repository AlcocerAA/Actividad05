using Actividad05.DTOs;
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

    public async Task<IEnumerable<MovimientosInventarioResponseDto>> GetAll()
    {
        var lista = await _unitOfWork.MovimientosInventario.GetAll();
        return lista.Select(MapToResponseDto);
    }

    public async Task<MovimientosInventarioResponseDto?> GetById(int id)
    {
        var m = await _unitOfWork.MovimientosInventario.GetById(id);
        return m == null ? null : MapToResponseDto(m);
    }

    public async Task<MovimientosInventarioResponseDto> Create(MovimientosInventarioCreateUpdateDto dto)
    {
        var entity = new MovimientosInventario
        {
            IdMateriaPrima = dto.IdMateriaPrima,
            IdProducto = dto.IdProducto,
            IdOrden = dto.IdOrden,
            Cantidad = dto.Cantidad,
            FechaMovimiento = dto.FechaMovimiento,
            Responsable = dto.Responsable
        };

        await _unitOfWork.MovimientosInventario.Add(entity);
        await _unitOfWork.SaveAsync();

        return MapToResponseDto(entity);
    }

    public async Task<bool> Update(int id, MovimientosInventarioCreateUpdateDto dto)
    {
        var existente = await _unitOfWork.MovimientosInventario.GetById(id);
        if (existente == null) return false;

        existente.IdMateriaPrima = dto.IdMateriaPrima;
        existente.IdProducto = dto.IdProducto;
        existente.IdOrden = dto.IdOrden;
        existente.Cantidad = dto.Cantidad;
        existente.FechaMovimiento = dto.FechaMovimiento;
        existente.Responsable = dto.Responsable;

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

    private static MovimientosInventarioResponseDto MapToResponseDto(MovimientosInventario m) => new()
    {
        IdMovimiento = m.IdMovimiento,
        IdMateriaPrima = m.IdMateriaPrima,
        IdProducto = m.IdProducto,
        IdOrden = m.IdOrden,
        Cantidad = m.Cantidad,
        FechaMovimiento = m.FechaMovimiento,
        Responsable = m.Responsable
    };
}
