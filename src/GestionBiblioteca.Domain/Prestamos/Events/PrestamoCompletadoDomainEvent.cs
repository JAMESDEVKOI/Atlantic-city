using GestionBiblioteca.Domain.Abstractions;

namespace GestionBiblioteca.Domain.Prestamos.Events;

public sealed record PrestamoCompletadoDomainEvent(Guid PrestamoId) : IDomainEvent;
