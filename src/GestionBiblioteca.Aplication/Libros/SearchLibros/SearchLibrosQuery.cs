using GestionBiblioteca.Aplication.Abstractions.Messaging;
using GestionBiblioteca.Aplication.Vehiculos.SearchVehiculos;

namespace GestionBiblioteca.Aplication.Libros.SearchLibros;

public sealed record SearchLibrosQuery(DateOnly fechaInicio, DateOnly fechaFin)
    : IQuery<IReadOnlyList<LibroResponse>>;
