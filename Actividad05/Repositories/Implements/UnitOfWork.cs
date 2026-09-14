using Actividad05.Models;
using Actividad05.Repositories;

namespace Actividad05.Repositories.Implements;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private bool _disposed = false;

    private IGenericRepository<EvaluacionesProveedor>? _evaluacionesProveedorRepository;
    private IGenericRepository<FormulaProduccion>? _formulaProduccionRepository;
    private IGenericRepository<InspeccionesCalidad>? _inspeccionesCalidadRepository;
    private IGenericRepository<MateriasPrima>? _materiasPrimaRepository;
    private IGenericRepository<MovimientosInventario>? _movimientosInventarioRepository;
    private IGenericRepository<OrdenesProduccion>? _ordenesProduccionRepository;
    private IGenericRepository<Producto>? _productoRepository;
    private IGenericRepository<Proveedore>? _proveedoreRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<EvaluacionesProveedor> EvaluacionesProveedorRepository =>
        _evaluacionesProveedorRepository ??= new GenericRepository<EvaluacionesProveedor>(_context);

    public IGenericRepository<FormulaProduccion> FormulaProduccionRepository =>
        _formulaProduccionRepository ??= new GenericRepository<FormulaProduccion>(_context);

    public IGenericRepository<InspeccionesCalidad> InspeccionesCalidadRepository =>
        _inspeccionesCalidadRepository ??= new GenericRepository<InspeccionesCalidad>(_context);

    public IGenericRepository<MateriasPrima> MateriasPrimaRepository =>
        _materiasPrimaRepository ??= new GenericRepository<MateriasPrima>(_context);

    public IGenericRepository<MovimientosInventario> MovimientosInventarioRepository =>
        _movimientosInventarioRepository ??= new GenericRepository<MovimientosInventario>(_context);

    public IGenericRepository<OrdenesProduccion> OrdenesProduccionRepository =>
        _ordenesProduccionRepository ??= new GenericRepository<OrdenesProduccion>(_context);

    public IGenericRepository<Producto> ProductoRepository =>
        _productoRepository ??= new GenericRepository<Producto>(_context);

    public IGenericRepository<Proveedore> ProveedoreRepository =>
        _proveedoreRepository ??= new GenericRepository<Proveedore>(_context);

    public int Save()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
