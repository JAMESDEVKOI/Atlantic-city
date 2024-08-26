namespace CleanArchitecture.Application.Prestamoes.GetPrestamo;

public sealed class PrestamoResponse
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public Guid BlibliotecarioId { get; init; }
    public int Status { get; init; }
    public decimal PrecioAlquier { get; init; }
    public string? TipoMonedaAlquier { get; init; }
    public decimal PrecioMantenimiento { get; init; }
    public decimal PrecioTotal { get; init; }
    public string? PrecioTotalTipoMoneda { get; init; }
    public DateOnly DuracionInicio { get; init; }
    public DateOnly DuracionFinal { get; init; }
    public DateTime FechaCreacion { get; init; }
}
