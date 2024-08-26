using CleanArchitecture.Application.Prestamoes.GetPrestamo;
using Dapper;
using GestionBiblioteca.Aplication.Abstractions.Data;
using GestionBiblioteca.Aplication.Abstractions.Messaging;
using GestionBiblioteca.Domain.Abstractions;

namespace GestionBiblioteca.Aplication.Prestamos.GetPrestamo;

internal sealed class GetPrestamoQueryHandler : IQueryHandler<GetPrestamoQuery, PrestamoResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetPrestamoQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<PrestamoResponse>> Handle(
        GetPrestamoQuery request,
        CancellationToken cancellationToken
    )
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var sql = """
            SELECT
                id as Id,
                bibliotecario_id as BibliotecarioId,
                user_id as UserId,
                precio_por_periodo as PrecioPrestamo,
                precio_por_periodo_tipo_moneda as TipoMonedaPrestamo,
                precio_mantenimiento as PrecioMantenimiento,
                precio_mantenimiento_tipo_moneda as TipoMonedaMantenimiento,
                precio_total as PrecioTotal,
                precio_total_tipo_moneda as PrecioTotalTipoMoneda,
                duracion_inicio as DuracionInicio,
                duracion_final as DuracionFinal,
                fecha_creacion as FechaCreacion
            FROM prestamos WHERE id = @PrestamoId
        """;

        var Prestamo = await connection.QueryFirstOrDefaultAsync<PrestamoResponse>(
            sql,
            new { request.PrestamoId }
        );

        return Prestamo!;
    }
}
