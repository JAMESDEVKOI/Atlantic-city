
using GestionBiblioteca.Aplication.Abstractions.Messaging;

namespace GestionBiblioteca.Aplication.Prestamos.ReservarPrestamo;
public record ReservarPrestamoCommand(
    Guid BibliotecarioId,
    Guid UserId,
    DateOnly FechaInicio,
    DateOnly FechaFin
) : ICommand<Guid>;
