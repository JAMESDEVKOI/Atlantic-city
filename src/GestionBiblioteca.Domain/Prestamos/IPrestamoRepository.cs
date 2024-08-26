using GestionBiblioteca.Domain.Libros;

namespace GestionBiblioteca.Domain.Prestamos;

public interface IPrestamoRepository
{
    Task<Prestamo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> IsOverlappingAsync(
        Libro libro,
        DateRage dateRage,
        CancellationToken cancellationToken = default
    );
    void Add(Prestamo prestamo);
}
