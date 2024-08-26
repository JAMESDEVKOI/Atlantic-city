using GestionBiblioteca.Domain.Abstractions;

namespace GestionBiblioteca.Domain.Prestamos;

public static class PrestamoErrors
{
    public static Error NotFound = new Error(
        "Prestamo.NotFound",
        "El Prestamo con el Id especificado no fue encontrado"
    );

    public static Error Overlap = new Error(
        "Prestamo.Overlap",
        "El Prestamo esta siendo tomado por 2 o más clientes al mismo tiempo en la misma fecha"
    );

    public static Error NotReserved = new Error(
        "Prestamo.NotReserved",
        "El Prestamo no ha sido reservado"
    );

    public static Error NotConfirmado = new Error(
        "Prestamo.NotConfirmed",
        "El Prestamo no ha sido confirmado"
    );

    public static Error AlreadyStatus = new Error(
        "Prestamo.AlreadyStatus",
        "El Prestamo ya ha comenzado"
    );
}
