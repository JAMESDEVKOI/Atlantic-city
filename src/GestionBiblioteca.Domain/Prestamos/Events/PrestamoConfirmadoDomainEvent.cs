using GestionBiblioteca.Domain.Abstractions;

namespace GestionBiblioteca.Domain.Prestamos.Events;

public sealed record PrestamoConfirmadoDomainEvent(Guid PrestamoId) : IDomainEvent;