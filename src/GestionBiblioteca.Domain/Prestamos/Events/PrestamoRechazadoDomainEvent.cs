using GestionBiblioteca.Domain.Abstractions;

namespace GestionBiblioteca.Domain.Prestamos.Events;

public sealed record PrestamoRechazadoDomainEvent(Guid PrestamoId) : IDomainEvent;