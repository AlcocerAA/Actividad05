using Actividad05.Models;
using Actividad05.Repositories;

namespace Actividad05.Services.Implements;

public class ProductoService : IProductoService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Producto>> GetAll()
    {
        return await _unitOfWork.Productos.GetAll();
    }

    public async Task<Producto?> GetById(int id)
    {
        return await _unitOfWork.Productos.GetById(id);
    }

    public async Task<Producto> Create(Producto entity)
    {
        await _unitOfWork.Productos.Add(entity);
        await _unitOfWork.SaveAsync();
        return entity;
    }

    public async Task<bool> Update(int id, Producto entity)
    {
        var existente = await _unitOfWork.Productos.GetById(id);
        if (existente == null) return false;

        existente.Nombre = entity.Nombre;
        existente.Descripcion = entity.Descripcion;
        existente.UnidadMedida = entity.UnidadMedida;
        existente.StockActual = entity.StockActual;
        existente.StockMinimo = entity.StockMinimo;
        existente.CostoEstimado = entity.CostoEstimado;

        _unitOfWork.Productos.Update(existente);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var existente = await _unitOfWork.Productos.GetById(id);
        if (existente == null) return false;

        await _unitOfWork.Productos.Delete(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
