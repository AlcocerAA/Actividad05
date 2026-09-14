using Actividad05.DTOs;
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

    public async Task<IEnumerable<EvaluacionesProveedorResponseDto>> GetAll()
    {
        var lista = await _unitOfWork.EvaluacionesProveedores.GetAll();
        return lista.Select(MapToResponseDto);
    }

    public async Task<EvaluacionesProveedorResponseDto?> GetById(int id)
    {
        var e = await _unitOfWork.EvaluacionesProveedores.GetById(id);
        return e == null ? null : MapToResponseDto(e);
    }

    public async Task<EvaluacionesProveedorResponseDto> Create(EvaluacionesProveedorCreateUpdateDto dto)
    {
        var entity = new EvaluacionesProveedor
        {
            IdProveedor = dto.IdProveedor,
            FechaEvaluacion = dto.FechaEvaluacion,
            Puntualidad = dto.Puntualidad,
            CalidadInsumo = dto.CalidadInsumo,
            PrecioCompetitivo = dto.PrecioCompetitivo,
            Observaciones = dto.Observaciones
        };

        await _unitOfWork.EvaluacionesProveedores.Add(entity);
        await _unitOfWork.SaveAsync();

        return MapToResponseDto(entity);
    }

    public async Task<bool> Update(int id, EvaluacionesProveedorCreateUpdateDto dto)
    {
        var existente = await _unitOfWork.EvaluacionesProveedores.GetById(id);
        if (existente == null) return false;

        existente.IdProveedor = dto.IdProveedor;
        existente.FechaEvaluacion = dto.FechaEvaluacion;
        existente.Puntualidad = dto.Puntualidad;
        existente.CalidadInsumo = dto.CalidadInsumo;
        existente.PrecioCompetitivo = dto.PrecioCompetitivo;
        existente.Observaciones = dto.Observaciones;

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

    private static EvaluacionesProveedorResponseDto MapToResponseDto(EvaluacionesProveedor e) => new()
    {
        IdEvaluacion = e.IdEvaluacion,
        IdProveedor = e.IdProveedor,
        FechaEvaluacion = e.FechaEvaluacion,
        Puntualidad = e.Puntualidad,
        CalidadInsumo = e.CalidadInsumo,
        PrecioCompetitivo = e.PrecioCompetitivo,
        Observaciones = e.Observaciones
    };
}
