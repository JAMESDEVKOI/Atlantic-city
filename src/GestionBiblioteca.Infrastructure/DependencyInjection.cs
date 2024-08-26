using Dapper;
using GestionBiblioteca.Aplication.Abstractions.Clock;
using GestionBiblioteca.Aplication.Abstractions.Data;
using GestionBiblioteca.Domain.Abstractions;
using GestionBiblioteca.Domain.Libros;
using GestionBiblioteca.Domain.Prestamos;
using GestionBiblioteca.Domain.Usuarios;
using GestionBiblioteca.Infrastructure.Clock;
using GestionBiblioteca.Infrastructure.Data;
using GestionBiblioteca.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestionBiblioteca.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        var connectionString =
            configuration.GetConnectionString("Database")
            ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ILibroRepository, LibroRepository>();
        services.AddScoped<IPrestamoRepository, PrestamoRepository>();
        services.AddScoped<IBibliotecarioRepository, BibliotecarioRepository>();
        services.AddScoped<ICopiaRepository, CopiaRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(
            _ => new SqlConnectionFactory(connectionString)
        );

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        return services;
    }
}
