using Actividad05.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad05.Repositories.Implements;

public class OrdenesProduccionRepository : IOrdenesProduccionRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<OrdenesProduccion> _dbSet;

    public OrdenesProduccionRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<OrdenesProduccion>();
    }

    public async Task<IEnumerable<OrdenesProduccion>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<OrdenesProduccion?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Add(OrdenesProduccion entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(OrdenesProduccion entity)
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
