using GestionBiblioteca.Domain.Abstractions;

namespace GestionBiblioteca.Domain.Libros;

public static class BibliotecarioErrors
{
    public static Error NotFound = new("Bibliotecario.NotFound", "No existe el bibliotecario por este id");
}
