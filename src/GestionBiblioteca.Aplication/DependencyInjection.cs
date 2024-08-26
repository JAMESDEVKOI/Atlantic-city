using FluentValidation;
using GestionBiblioteca.Aplication.Abstractions.Behaviors;
using GestionBiblioteca.Domain.Prestamos;
using Microsoft.Extensions.DependencyInjection;

namespace GestionBiblioteca.Aplication;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            configuration.AddOpenBehavior(typeof(LogginBehavior<,>));
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddTransient<PrecioService>();

        return services;
    }
}
