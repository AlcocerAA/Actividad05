using Actividad05.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad05.Repositories.Implements;

public class InspeccionesCalidadRepository : IInspeccionesCalidadRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<InspeccionesCalidad> _dbSet;

    public InspeccionesCalidadRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<InspeccionesCalidad>();
    }

    public async Task<IEnumerable<InspeccionesCalidad>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<InspeccionesCalidad?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Add(InspeccionesCalidad entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(InspeccionesCalidad entity)
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
