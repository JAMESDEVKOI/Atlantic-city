using GestionBiblioteca.Domain.Abstractions;

namespace GestionBiblioteca.Domain.Usuarios.Events;

public sealed record UserCreateDomainEvent(Guid userId) : IDomainEvent;
