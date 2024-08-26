using GestionBiblioteca.Domain.Libros;
using GestionBiblioteca.Domain.Shared;

namespace GestionBiblioteca.Domain.Prestamos;

public class PrecioService
{
    public PrecioDetalle CalcularPrecio(Libro libro, DateRage periodo)
    {
        var tipoMoneda = libro.Precio!.TipoMoneda;

        var precioPorPeriodo = new Moneda(periodo.CantidadDias * libro.Precio!.Monto, tipoMoneda);

        var precioTotal = Moneda.Zero();

        precioTotal += precioPorPeriodo;

        if (!libro!.Mantenimiento!.IsZero())
        {
            precioTotal += libro.Mantenimiento;
        }

        return new PrecioDetalle(precioPorPeriodo, libro.Mantenimiento, precioTotal);
    }
}
