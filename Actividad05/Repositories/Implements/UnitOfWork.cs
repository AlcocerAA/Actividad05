using Actividad05.Models;
using Actividad05.Repositories;

namespace Actividad05.Repositories.Implements;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IFormulaProduccionRepository FormulasProduccion { get; }

    public UnitOfWork(
        ApplicationDbContext context,
        IFormulaProduccionRepository formulaProduccionRepository)
    {
        _context = context;
        FormulasProduccion = formulaProduccionRepository;
    }

    public int Save()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}