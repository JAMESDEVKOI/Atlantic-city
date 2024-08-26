using GestionBiblioteca.Domain.Abstractions;
using MediatR;

namespace GestionBiblioteca.Aplication.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
