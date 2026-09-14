using Actividad05.DTOs;
using Actividad05.Models;
using Actividad05.Repositories;

namespace Actividad05.Services.Implements;

public class ProveedoreService : IProveedoreService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProveedoreService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProveedoreResponseDto>> GetAll()
    {
        var proveedores = await _unitOfWork.Proveedores.GetAll();
        return proveedores.Select(MapToResponseDto);
    }

    public async Task<ProveedoreResponseDto?> GetById(int id)
    {
        var p = await _unitOfWork.Proveedores.GetById(id);
        return p == null ? null : MapToResponseDto(p);
    }

    public async Task<ProveedoreResponseDto> Create(ProveedoreCreateUpdateDto dto)
    {
        var entity = new Proveedore
        {
            Nombre = dto.Nombre,
            Contacto = dto.Contacto,
            Telefono = dto.Telefono,
            Email = dto.Email,
            CalificacionPromedio = dto.CalificacionPromedio,
            Activo = dto.Activo
        };

        await _unitOfWork.Proveedores.Add(entity);
        await _unitOfWork.SaveAsync();

        return MapToResponseDto(entity);
    }

    public async Task<bool> Update(int id, ProveedoreCreateUpdateDto dto)
    {
        var existente = await _unitOfWork.Proveedores.GetById(id);
        if (existente == null) return false;

        existente.Nombre = dto.Nombre;
        existente.Contacto = dto.Contacto;
        existente.Telefono = dto.Telefono;
        existente.Email = dto.Email;
        existente.CalificacionPromedio = dto.CalificacionPromedio;
        existente.Activo = dto.Activo;

        _unitOfWork.Proveedores.Update(existente);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var existente = await _unitOfWork.Proveedores.GetById(id);
        if (existente == null) return false;

        await _unitOfWork.Proveedores.Delete(id);
        await _unitOfWork.SaveAsync();
        return true;
    }

    private static ProveedoreResponseDto MapToResponseDto(Proveedore p) => new()
    {
        IdProveedor = p.IdProveedor,
        Nombre = p.Nombre,
        Contacto = p.Contacto,
        Telefono = p.Telefono,
        Email = p.Email,
        CalificacionPromedio = p.CalificacionPromedio,
        Activo = p.Activo
    };
}
