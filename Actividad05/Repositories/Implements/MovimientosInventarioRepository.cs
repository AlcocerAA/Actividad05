using Actividad05.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad05.Repositories.Implements;

public class MovimientosInventarioRepository : IMovimientosInventarioRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<MovimientosInventario> _dbSet;

    public MovimientosInventarioRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<MovimientosInventario>();
    }

    public async Task<IEnumerable<MovimientosInventario>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<MovimientosInventario?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Add(MovimientosInventario entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(MovimientosInventario entity)
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
