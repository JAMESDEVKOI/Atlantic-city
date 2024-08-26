using GestionBiblioteca.Domain.Libros;
using GestionBiblioteca.Domain.Prestamos;
using Microsoft.EntityFrameworkCore;

namespace GestionBiblioteca.Infrastructure.Repositories;

internal sealed class PrestamoRepository : Repository<Prestamo>, IPrestamoRepository
{
    private static readonly PrestamoStatus[] ActivePrestamoStatuses =
    {
        PrestamoStatus.Reservado,
        PrestamoStatus.Confirmado,
        PrestamoStatus.Cancelado
    };

    public PrestamoRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }

    public async Task<bool> IsOverlappingAsync(
        Libro libro,
        DateRage duracion,
        CancellationToken cancellationToken = default
    )
    {
        return await DbContext
            .Set<Prestamo>()
            .AnyAsync(
                prestamo =>
                    prestamo.BibliotecarioId == libro.Id
                    && prestamo.Duracion!.Inicio <= duracion.Fin
                    && prestamo.Duracion.Fin >= duracion.Inicio
                    && ActivePrestamoStatuses.Contains(prestamo.Estado),
                cancellationToken
            );
    }
}
