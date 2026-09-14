using Actividad05.Models;
using Actividad05.Repositories;

namespace Actividad05.Services.Implements;

public class FormulaProduccionService : IFormulaProduccionService
{
    private readonly IUnitOfWork _unitOfWork;

    public FormulaProduccionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<FormulaProduccion>> GetAllFormulas()
    {
        return await _unitOfWork.FormulaProduccionRepository.GetAll();
    }

    public async Task<FormulaProduccion?> GetFormulaById(int idProducto, int idMateriaPrima)
    {
        return await _unitOfWork.FormulaProduccionRepository.GetById(idProducto);
    }

    public async Task<FormulaProduccion> CreateFormula(FormulaProduccion formula)
    {
        await _unitOfWork.FormulaProduccionRepository.Add(formula);
        await _unitOfWork.SaveAsync();
        return formula;
    }

    public async Task<bool> UpdateFormula(int idProducto, int idMateriaPrima, FormulaProduccion formula)
    {
        var existente = await _unitOfWork.FormulaProduccionRepository.GetById(idProducto);
        if (existente == null)
        {
            return false;
        }

        existente.CantidadRequerida = formula.CantidadRequerida;

        _unitOfWork.FormulaProduccionRepository.Update(existente);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> PatchFormula(int idProducto, int idMateriaPrima, FormulaProduccion formula)
    {
        var existente = await _unitOfWork.FormulaProduccionRepository.GetById(idProducto);
        if (existente == null)
        {
            return false;
        }

        if (formula.CantidadRequerida > 0)
        {
            existente.CantidadRequerida = formula.CantidadRequerida;
        }

        _unitOfWork.FormulaProduccionRepository.Update(existente);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteFormula(int idProducto, int idMateriaPrima)
    {
        var existente = await _unitOfWork.FormulaProduccionRepository.GetById(idProducto);
        if (existente == null)
        {
            return false;
        }

        await _unitOfWork.FormulaProduccionRepository.Delete(idProducto);
        await _unitOfWork.SaveAsync();
        return true;
    }
}