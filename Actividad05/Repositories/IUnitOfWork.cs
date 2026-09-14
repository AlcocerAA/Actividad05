namespace Actividad05.Repositories;

public interface IUnitOfWork : IDisposable
{
    IEvaluacionesProveedorRepository EvaluacionesProveedores { get; }
    IFormulaProduccionRepository FormulasProduccion { get; }
    IInspeccionesCalidadRepository InspeccionesCalidad { get; }
    IMateriasPrimaRepository MateriasPrimas { get; }
    IMovimientosInventarioRepository MovimientosInventario { get; }
    IOrdenesProduccionRepository OrdenesProduccion { get; }
    IProductoRepository Productos { get; }
    IProveedoreRepository Proveedores { get; }

    int Save();
    Task<int> SaveAsync();
}
