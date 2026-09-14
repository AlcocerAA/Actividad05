using Actividad05.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad05.Repositories.Implements;

public class ProveedoreRepository : IProveedoreRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Proveedore> _dbSet;

    public ProveedoreRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<Proveedore>();
    }

    public async Task<IEnumerable<Proveedore>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Proveedore?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Add(Proveedore entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(Proveedore entity)
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
