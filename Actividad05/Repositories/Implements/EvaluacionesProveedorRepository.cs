using Actividad05.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad05.Repositories.Implements;

public class EvaluacionesProveedorRepository : IEvaluacionesProveedorRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<EvaluacionesProveedor> _dbSet;

    public EvaluacionesProveedorRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<EvaluacionesProveedor>();
    }

    public async Task<IEnumerable<EvaluacionesProveedor>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<EvaluacionesProveedor?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Add(EvaluacionesProveedor entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(EvaluacionesProveedor entity)
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
