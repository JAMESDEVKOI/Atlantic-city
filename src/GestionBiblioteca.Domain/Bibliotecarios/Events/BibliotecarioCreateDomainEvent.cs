using GestionBiblioteca.Domain.Abstractions;

namespace GestionBiblioteca.Domain.Bibliotecarios.Events;

public sealed record BibliotecarioCreateDomainEvent(Guid userBibliotecarioId) : IDomainEvent;
