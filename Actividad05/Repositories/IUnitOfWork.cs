namespace Actividad05.Repositories;

public interface IUnitOfWork : IDisposable
{
    IFormulaProduccionRepository FormulasProduccion { get; }
    int Save();
    Task<int> SaveAsync();
}