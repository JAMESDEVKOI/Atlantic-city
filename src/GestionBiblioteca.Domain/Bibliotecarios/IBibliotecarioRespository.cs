using GestionBiblioteca.Domain.Bibliotecarios;

namespace CleanArchitecture.Domain.Vehiculos;

public interface IBibliotecarioRepository
{
    Task<Bibliotecario?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
