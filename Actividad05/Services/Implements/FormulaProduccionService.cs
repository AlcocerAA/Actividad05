using Actividad05.DTOs;
using Actividad05.Models;
using Actividad05.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Actividad05.Services.Implements;

public class FormulaProduccionService : IFormulaProduccionService
{
    private readonly IUnitOfWork _unitOfWork;

    public FormulaProduccionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<FormulaProduccionResponseDto>> GetAllFormulas()
    {
        var formulas = await _unitOfWork.FormulasProduccion.GetAll();
        return formulas.Select(f => new FormulaProduccionResponseDto
        {
            IdProducto = f.IdProducto,
            IdMateriaPrima = f.IdMateriaPrima,
            CantidadRequerida = f.CantidadRequerida
        });
    }

    public async Task<FormulaProduccionResponseDto?> GetFormulaById(int idProducto, int idMateriaPrima)
    {
        var f = await _unitOfWork.FormulasProduccion.GetById(idProducto, idMateriaPrima);
        if (f == null) return null;

        return new FormulaProduccionResponseDto
        {
            IdProducto = f.IdProducto,
            IdMateriaPrima = f.IdMateriaPrima,
            CantidadRequerida = f.CantidadRequerida
        };
    }

    public async Task<FormulaProduccionResponseDto> CreateFormula(FormulaProduccionCreateDto dto)
    {
        try
        {
            var entity = new FormulaProduccion
            {
                IdProducto = dto.IdProducto,
                IdMateriaPrima = dto.IdMateriaPrima,
                CantidadRequerida = dto.CantidadRequerida
            };

            await _unitOfWork.FormulasProduccion.Add(entity);
            await _unitOfWork.SaveAsync();

            return new FormulaProduccionResponseDto
            {
                IdProducto = entity.IdProducto,
                IdMateriaPrima = entity.IdMateriaPrima,
                CantidadRequerida = entity.CantidadRequerida
            };
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException is PostgresException pgEx)
            {
                if (pgEx.SqlState == "23503")
                {
                    throw new ArgumentException("El IdProducto o el IdMateriaPrima especificado no existe en la base de datos.");
                }
                if (pgEx.SqlState == "23505")
                {
                    throw new InvalidOperationException("Ya existe una formula registrada para ese IdProducto e IdMateriaPrima.");
                }
            }
            throw new Exception("Error al procesar la formula de produccion en la base de datos.");
        }
    }

    public async Task<bool> UpdateFormula(int idProducto, int idMateriaPrima, FormulaProduccionUpdateDto dto)
    {
        var existente = await _unitOfWork.FormulasProduccion.GetById(idProducto, idMateriaPrima);
        if (existente == null) return false;

        existente.CantidadRequerida = dto.CantidadRequerida;

        _unitOfWork.FormulasProduccion.Update(existente);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> PatchFormula(int idProducto, int idMateriaPrima, FormulaProduccionUpdateDto dto)
    {
        var existente = await _unitOfWork.FormulasProduccion.GetById(idProducto, idMateriaPrima);
        if (existente == null) return false;

        if (dto.CantidadRequerida > 0)
        {
            existente.CantidadRequerida = dto.CantidadRequerida;
        }

        _unitOfWork.FormulasProduccion.Update(existente);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteFormula(int idProducto, int idMateriaPrima)
    {
        var existente = await _unitOfWork.FormulasProduccion.GetById(idProducto, idMateriaPrima);
        if (existente == null) return false;

        await _unitOfWork.FormulasProduccion.Delete(idProducto, idMateriaPrima);
        await _unitOfWork.SaveAsync();
        return true;
    }
}