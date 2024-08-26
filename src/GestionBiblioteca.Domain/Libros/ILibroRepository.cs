namespace GestionBiblioteca.Domain.Libros;

public interface ILibroRepository
{
    Task<Libro?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
