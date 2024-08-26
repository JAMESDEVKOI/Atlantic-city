using CleanArchitecture.Application.Prestamoes.GetPrestamo;
using GestionBiblioteca.Aplication.Abstractions.Messaging;

namespace GestionBiblioteca.Aplication.Prestamos.GetPrestamo;

public sealed record GetPrestamoQuery(Guid PrestamoId) : IQuery<PrestamoResponse>;
