using Actividad05.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad05.Repositories.Implements;

public class MateriasPrimaRepository : IMateriasPrimaRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<MateriasPrima> _dbSet;

    public MateriasPrimaRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<MateriasPrima>();
    }

    public async Task<IEnumerable<MateriasPrima>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<MateriasPrima?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Add(MateriasPrima entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(MateriasPrima entity)
    {
        _dbSet.Update(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }
}
