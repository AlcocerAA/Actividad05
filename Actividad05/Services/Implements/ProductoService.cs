using Actividad05.DTOs;
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

    public async Task<IEnumerable<ProductoResponseDto>> GetAll()
    {
        var productos = await _unitOfWork.Productos.GetAll();
        return productos.Select(MapToResponseDto);
    }

    public async Task<ProductoResponseDto?> GetById(int id)
    {
        var p = await _unitOfWork.Productos.GetById(id);
        return p == null ? null : MapToResponseDto(p);
    }

    public async Task<ProductoResponseDto> Create(ProductoCreateUpdateDto dto)
    {
        var entity = new Producto
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            UnidadMedida = dto.UnidadMedida,
            CostoEstimado = dto.CostoEstimado,
            StockActual = dto.StockActual,
            StockMinimo = dto.StockMinimo
        };

        await _unitOfWork.Productos.Add(entity);
        await _unitOfWork.SaveAsync();

        return MapToResponseDto(entity);
    }

    public async Task<bool> Update(int id, ProductoCreateUpdateDto dto)
    {
        var existente = await _unitOfWork.Productos.GetById(id);
        if (existente == null) return false;

        existente.Nombre = dto.Nombre;
        existente.Descripcion = dto.Descripcion;
        existente.UnidadMedida = dto.UnidadMedida;
        existente.CostoEstimado = dto.CostoEstimado;
        existente.StockActual = dto.StockActual;
        existente.StockMinimo = dto.StockMinimo;

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

    private static ProductoResponseDto MapToResponseDto(Producto p) => new()
    {
        IdProducto = p.IdProducto,
        Nombre = p.Nombre,
        Descripcion = p.Descripcion,
        UnidadMedida = p.UnidadMedida,
        CostoEstimado = p.CostoEstimado,
        StockActual = p.StockActual,
        StockMinimo = p.StockMinimo
    };
}
