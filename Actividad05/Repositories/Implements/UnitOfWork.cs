using Actividad05.Models;
using Actividad05.Repositories;

namespace Actividad05.Repositories.Implements;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private bool _disposed = false;

    private IEvaluacionesProveedorRepository? _evaluacionesProveedores;
    private IFormulaProduccionRepository? _formulasProduccion;
    private IInspeccionesCalidadRepository? _inspeccionesCalidad;
    private IMateriasPrimaRepository? _materiasPrimas;
    private IMovimientosInventarioRepository? _movimientosInventario;
    private IOrdenesProduccionRepository? _ordenesProduccion;
    private IProductoRepository? _productos;
    private IProveedoreRepository? _proveedores;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEvaluacionesProveedorRepository EvaluacionesProveedores =>
        _evaluacionesProveedores ??= new EvaluacionesProveedorRepository(_context);

    public IFormulaProduccionRepository FormulasProduccion =>
        _formulasProduccion ??= new FormulaProduccionRepository(_context);

    public IInspeccionesCalidadRepository InspeccionesCalidad =>
        _inspeccionesCalidad ??= new InspeccionesCalidadRepository(_context);

    public IMateriasPrimaRepository MateriasPrimas =>
        _materiasPrimas ??= new MateriasPrimaRepository(_context);

    public IMovimientosInventarioRepository MovimientosInventario =>
        _movimientosInventario ??= new MovimientosInventarioRepository(_context);

    public IOrdenesProduccionRepository OrdenesProduccion =>
        _ordenesProduccion ??= new OrdenesProduccionRepository(_context);

    public IProductoRepository Productos =>
        _productos ??= new ProductoRepository(_context);

    public IProveedoreRepository Proveedores =>
        _proveedores ??= new ProveedoreRepository(_context);

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
