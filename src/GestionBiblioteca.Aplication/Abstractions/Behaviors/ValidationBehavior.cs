using FluentValidation;
using GestionBiblioteca.Aplication.Abstractions.Exceptions;
using GestionBiblioteca.Aplication.Abstractions.Messaging;
using MediatR;

namespace GestionBiblioteca.Aplication.Abstractions.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);
        var validationError = _validators
            .Select(validators => validators.Validate(context))
            .Where(validationResult => validationResult.Errors.Any())
            .SelectMany(validationResult => validationResult.Errors)
            .Select(
                validationFailure =>
                    new ValidationError(
                        validationFailure.PropertyName,
                        validationFailure.ErrorMessage
                    )
            )
            .ToList();
        if (validationError.Any())
        {
            throw new Exceptions.ValidationException(validationError);
        }

        return await next();
    }
}
