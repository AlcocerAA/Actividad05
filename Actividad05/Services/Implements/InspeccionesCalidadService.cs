using Actividad05.DTOs;
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

    public async Task<IEnumerable<InspeccionesCalidadResponseDto>> GetAll()
    {
        var lista = await _unitOfWork.InspeccionesCalidad.GetAll();
        return lista.Select(MapToResponseDto);
    }

    public async Task<InspeccionesCalidadResponseDto?> GetById(int id)
    {
        var i = await _unitOfWork.InspeccionesCalidad.GetById(id);
        return i == null ? null : MapToResponseDto(i);
    }

    public async Task<InspeccionesCalidadResponseDto> Create(InspeccionesCalidadCreateUpdateDto dto)
    {
        var entity = new InspeccionesCalidad
        {
            IdOrden = dto.IdOrden,
            Inspector = dto.Inspector,
            Etapa = dto.Etapa,
            FechaInspeccion = dto.FechaInspeccion,
            CantidadInspeccionada = dto.CantidadInspeccionada,
            CantidadDefectuosa = dto.CantidadDefectuosa,
            Observaciones = dto.Observaciones
        };

        await _unitOfWork.InspeccionesCalidad.Add(entity);
        await _unitOfWork.SaveAsync();

        return MapToResponseDto(entity);
    }

    public async Task<bool> Update(int id, InspeccionesCalidadCreateUpdateDto dto)
    {
        var existente = await _unitOfWork.InspeccionesCalidad.GetById(id);
        if (existente == null) return false;

        existente.IdOrden = dto.IdOrden;
        existente.Inspector = dto.Inspector;
        existente.Etapa = dto.Etapa;
        existente.FechaInspeccion = dto.FechaInspeccion;
        existente.CantidadInspeccionada = dto.CantidadInspeccionada;
        existente.CantidadDefectuosa = dto.CantidadDefectuosa;
        existente.Observaciones = dto.Observaciones;

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

    private static InspeccionesCalidadResponseDto MapToResponseDto(InspeccionesCalidad i) => new()
    {
        IdInspeccion = i.IdInspeccion,
        IdOrden = i.IdOrden,
        Inspector = i.Inspector,
        Etapa = i.Etapa,
        FechaInspeccion = i.FechaInspeccion,
        CantidadInspeccionada = i.CantidadInspeccionada,
        CantidadDefectuosa = i.CantidadDefectuosa,
        Observaciones = i.Observaciones
    };
}
