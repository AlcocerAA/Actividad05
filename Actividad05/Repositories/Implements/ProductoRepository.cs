using Actividad05.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad05.Repositories.Implements;

public class ProductoRepository : IProductoRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Producto> _dbSet;

    public ProductoRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<Producto>();
    }

    public async Task<IEnumerable<Producto>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Producto?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Add(Producto entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(Producto entity)
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
