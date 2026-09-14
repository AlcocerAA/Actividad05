using Actividad05.DTOs;
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

    public async Task<IEnumerable<MateriasPrimaResponseDto>> GetAll()
    {
        var lista = await _unitOfWork.MateriasPrimas.GetAll();
        return lista.Select(MapToResponseDto);
    }

    public async Task<MateriasPrimaResponseDto?> GetById(int id)
    {
        var m = await _unitOfWork.MateriasPrimas.GetById(id);
        return m == null ? null : MapToResponseDto(m);
    }

    public async Task<MateriasPrimaResponseDto> Create(MateriasPrimaCreateUpdateDto dto)
    {
        var entity = new MateriasPrima
        {
            IdProveedor = dto.IdProveedor,
            Nombre = dto.Nombre,
            UnidadMedida = dto.UnidadMedida,
            PrecioUnitario = dto.PrecioUnitario,
            StockActual = dto.StockActual,
            StockMinimo = dto.StockMinimo
        };

        await _unitOfWork.MateriasPrimas.Add(entity);
        await _unitOfWork.SaveAsync();

        return MapToResponseDto(entity);
    }

    public async Task<bool> Update(int id, MateriasPrimaCreateUpdateDto dto)
    {
        var existente = await _unitOfWork.MateriasPrimas.GetById(id);
        if (existente == null) return false;

        existente.IdProveedor = dto.IdProveedor;
        existente.Nombre = dto.Nombre;
        existente.UnidadMedida = dto.UnidadMedida;
        existente.PrecioUnitario = dto.PrecioUnitario;
        existente.StockActual = dto.StockActual;
        existente.StockMinimo = dto.StockMinimo;

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

    private static MateriasPrimaResponseDto MapToResponseDto(MateriasPrima m) => new()
    {
        IdMateriaPrima = m.IdMateriaPrima,
        IdProveedor = m.IdProveedor,
        Nombre = m.Nombre,
        UnidadMedida = m.UnidadMedida,
        PrecioUnitario = m.PrecioUnitario,
        StockActual = m.StockActual,
        StockMinimo = m.StockMinimo
    };
}
