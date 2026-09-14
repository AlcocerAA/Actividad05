using Actividad05.Models;
using Actividad05.Repositories;

namespace Actividad05.Services.Implements;

public class MateriasPrimaService : IMateriasPrimaService
{
    private readonly IUnitOfWork _unitOfWork;

    public MateriasPrimaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<MateriasPrima>> GetAll()
    {
        return await _unitOfWork.MateriasPrimas.GetAll();
    }

    public async Task<MateriasPrima?> GetById(int id)
    {
        return await _unitOfWork.MateriasPrimas.GetById(id);
    }

    public async Task<MateriasPrima> Create(MateriasPrima entity)
    {
        await _unitOfWork.MateriasPrimas.Add(entity);
        await _unitOfWork.SaveAsync();
        return entity;
    }

    public async Task<bool> Update(int id, MateriasPrima entity)
    {
        var existente = await _unitOfWork.MateriasPrimas.GetById(id);
        if (existente == null) return false;

        existente.Nombre = entity.Nombre;
        existente.UnidadMedida = entity.UnidadMedida;
        existente.StockActual = entity.StockActual;
        existente.StockMinimo = entity.StockMinimo;
        existente.PrecioUnitario = entity.PrecioUnitario;
        existente.IdProveedor = entity.IdProveedor;

        _unitOfWork.MateriasPrimas.Update(existente);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var existente = await _unitOfWork.MateriasPrimas.GetById(id);
        if (existente == null) return false;

        await _unitOfWork.MateriasPrimas.Delete(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
