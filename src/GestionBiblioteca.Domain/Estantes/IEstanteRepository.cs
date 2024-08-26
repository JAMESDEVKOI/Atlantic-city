namespace GestionBiblioteca.Domain.Estantes;

public interface IEstanteRepository
{
    Task<Estante?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
