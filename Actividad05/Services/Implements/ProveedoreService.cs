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

    public async Task<IEnumerable<Proveedore>> GetAll()
    {
        return await _unitOfWork.Proveedores.GetAll();
    }

    public async Task<Proveedore?> GetById(int id)
    {
        return await _unitOfWork.Proveedores.GetById(id);
    }

    public async Task<Proveedore> Create(Proveedore entity)
    {
        await _unitOfWork.Proveedores.Add(entity);
        await _unitOfWork.SaveAsync();
        return entity;
    }

    public async Task<bool> Update(int id, Proveedore entity)
    {
        var existente = await _unitOfWork.Proveedores.GetById(id);
        if (existente == null) return false;

        existente.Nombre = entity.Nombre;
        existente.Contacto = entity.Contacto;
        existente.Telefono = entity.Telefono;
        existente.Email = entity.Email;
        existente.CalificacionPromedio = entity.CalificacionPromedio;
        existente.Activo = entity.Activo;

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
}
