using GestionBiblioteca.Domain.Abstractions;

namespace GestionBiblioteca.Domain.Libros;

public static class LibrosErrors
{
    public static Error NotFound = new("Libro.NotFound", "No existe el libro por este id");
}
