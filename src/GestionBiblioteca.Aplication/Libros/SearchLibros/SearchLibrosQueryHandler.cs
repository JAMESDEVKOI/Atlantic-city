using Dapper;
using GestionBiblioteca.Aplication.Abstractions.Data;
using GestionBiblioteca.Aplication.Abstractions.Messaging;
using GestionBiblioteca.Aplication.Vehiculos.SearchVehiculos;
using GestionBiblioteca.Domain.Abstractions;
using GestionBiblioteca.Domain.Prestamos;

namespace GestionBiblioteca.Aplication.Libros.SearchLibros;

internal sealed class SearchLibrosQueryHandler
    : IQueryHandler<SearchLibrosQuery, IReadOnlyList<LibroResponse>>
{
    private static readonly int[] ActivePrestamoStatuses =
    {
        (int)PrestamoStatus.Reservado,
        (int)PrestamoStatus.Confirmado,
        (int)PrestamoStatus.Completado
    };

    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchLibrosQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<LibroResponse>>> Handle(
        SearchLibrosQuery request,
        CancellationToken cancellationToken
    )
    {
        if (request.fechaInicio > request.fechaFin)
        {
            return new List<LibroResponse>();
        }
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                a.id as Id,
                a.titulo as Titulo,
                a.autor as Autor,
                a.editorial as Editorial,
                a.publicacion as Publicacion,
                a.categoria as Categoria,
             FROM libros AS a
             WHERE NOT EXISTS
             (
                    SELECT 1 
                    FROM prestamos AS b
                    WHERE 
                        b.libro_id = a.id  AND
                        b.duracion_inicio <= @EndDate AND
                        b.duracion_fin  >= @StartDate AND
                        b.status = ANY(@ActivePrestamoStatuses)
             ) 
        """;

        var vehiculos = await connection.QueryAsync<LibroResponse>(
            sql,
            new
            {
                StartDate = request.fechaInicio,
                EndDate = request.fechaFin,
                ActivePrestamoStatuses = ActivePrestamoStatuses
            }
        );

        return vehiculos.ToList();
    }
}
