using GestionBiblioteca.Domain.Abstractions;
using MediatR;

namespace GestionBiblioteca.Aplication.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse> { }
