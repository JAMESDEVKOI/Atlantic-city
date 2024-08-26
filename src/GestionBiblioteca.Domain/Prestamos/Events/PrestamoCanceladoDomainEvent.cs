using GestionBiblioteca.Domain.Abstractions;

namespace GestionBiblioteca.Domain.Prestamos.Events;


public sealed record PrestamoCanceladoDomainEvent(Guid PrestamoId) : IDomainEvent;