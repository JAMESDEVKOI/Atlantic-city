using GestionBiblioteca.Domain.Abstractions;
using MediatR;

namespace GestionBiblioteca.Aplication.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand { }

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand { }

public interface IBaseCommand { }
