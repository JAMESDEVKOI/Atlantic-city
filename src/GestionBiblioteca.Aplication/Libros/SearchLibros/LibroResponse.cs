namespace GestionBiblioteca.Aplication.Vehiculos.SearchVehiculos;

public sealed class LibroResponse
{
    public Guid Id { get; init; }
    public decimal Precio { get; init; }
    public string? TipoMoneda { get; init; }
}
