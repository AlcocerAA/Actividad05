using Actividad05.Models;

namespace Actividad05.Repositories;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<EvaluacionesProveedor> EvaluacionesProveedorRepository { get; }
    IGenericRepository<FormulaProduccion> FormulaProduccionRepository { get; }
    IGenericRepository<InspeccionesCalidad> InspeccionesCalidadRepository { get; }
    IGenericRepository<MateriasPrima> MateriasPrimaRepository { get; }
    IGenericRepository<MovimientosInventario> MovimientosInventarioRepository { get; }
    IGenericRepository<OrdenesProduccion> OrdenesProduccionRepository { get; }
    IGenericRepository<Producto> ProductoRepository { get; }
    IGenericRepository<Proveedore> ProveedoreRepository { get; }

    int Save();
    Task<int> SaveAsync();
}
