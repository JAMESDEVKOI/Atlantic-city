namespace GestionBiblioteca.Domain.Copias;

public interface ICopiRepository
{
    Task<Copia?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
