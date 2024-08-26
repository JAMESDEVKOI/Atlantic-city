using GestionBiblioteca.Domain.Shared;


namespace GestionBiblioteca.Domain.Prestamos;


public record PrecioDetalle(Moneda precioPorPeriodo, Moneda mantenimiento, Moneda precioTotal);
