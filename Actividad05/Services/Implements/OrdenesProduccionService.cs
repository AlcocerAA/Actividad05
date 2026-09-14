using Actividad05.DTOs;
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

    public async Task<IEnumerable<OrdenesProduccionResponseDto>> GetAll()
    {
        var lista = await _unitOfWork.OrdenesProduccion.GetAll();
        return lista.Select(MapToResponseDto);
    }

    public async Task<OrdenesProduccionResponseDto?> GetById(int id)
    {
        var o = await _unitOfWork.OrdenesProduccion.GetById(id);
        return o == null ? null : MapToResponseDto(o);
    }

    public async Task<OrdenesProduccionResponseDto> Create(OrdenesProduccionCreateUpdateDto dto)
    {
        var entity = new OrdenesProduccion
        {
            IdProducto = dto.IdProducto,
            LineaProduccion = dto.LineaProduccion,
            Responsable = dto.Responsable,
            CantidadPlaneada = dto.CantidadPlaneada,
            CantidadProducida = dto.CantidadProducida,
            FechaPlanificada = dto.FechaPlanificada,
            FechaInicio = dto.FechaInicio,
            FechaEntrega = dto.FechaEntrega
        };

        await _unitOfWork.OrdenesProduccion.Add(entity);
        await _unitOfWork.SaveAsync();

        return MapToResponseDto(entity);
    }

    public async Task<bool> Update(int id, OrdenesProduccionCreateUpdateDto dto)
    {
        var existente = await _unitOfWork.OrdenesProduccion.GetById(id);
        if (existente == null) return false;

        existente.IdProducto = dto.IdProducto;
        existente.LineaProduccion = dto.LineaProduccion;
        existente.Responsable = dto.Responsable;
        existente.CantidadPlaneada = dto.CantidadPlaneada;
        existente.CantidadProducida = dto.CantidadProducida;
        existente.FechaPlanificada = dto.FechaPlanificada;
        existente.FechaInicio = dto.FechaInicio;
        existente.FechaEntrega = dto.FechaEntrega;

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

    private static OrdenesProduccionResponseDto MapToResponseDto(OrdenesProduccion o) => new()
    {
        IdOrden = o.IdOrden,
        IdProducto = o.IdProducto,
        LineaProduccion = o.LineaProduccion,
        Responsable = o.Responsable,
        CantidadPlaneada = o.CantidadPlaneada,
        CantidadProducida = o.CantidadProducida,
        FechaPlanificada = o.FechaPlanificada,
        FechaInicio = o.FechaInicio,
        FechaEntrega = o.FechaEntrega
    };
}
