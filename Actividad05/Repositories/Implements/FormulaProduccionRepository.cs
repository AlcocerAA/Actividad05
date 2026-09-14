using Actividad05.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad05.Repositories.Implements;

public class FormulaProduccionRepository : IFormulaProduccionRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<FormulaProduccion> _dbSet;

    public FormulaProduccionRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<FormulaProduccion>();
    }

    public async Task<IEnumerable<FormulaProduccion>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<FormulaProduccion?> GetById(int idProducto, int idMateriaPrima)
    {
        return await _dbSet.FindAsync(idProducto, idMateriaPrima);
    }

    public async Task Add(FormulaProduccion formula)
    {
        await _dbSet.AddAsync(formula);
    }

    public void Update(FormulaProduccion formula)
    {
        _dbSet.Update(formula);
    }

    public async Task Delete(int idProducto, int idMateriaPrima)
    {
        var entity = await _dbSet.FindAsync(idProducto, idMateriaPrima);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }
}