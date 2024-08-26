using GestionBiblioteca.Domain.Abstractions;
using GestionBiblioteca.Domain.Shared;

namespace GestionBiblioteca.Domain.Libros;

public sealed class Libro : Entity
{
    private Libro() { }

    public Libro(
        Guid id,
        Titulo titulo,
        Autor autor,
        Editorial editorial,
        Moneda precio,
        Publicacion publicacion,
        Categoria categoria,
        DateTime? fechaUltimaPrestamo,
        Moneda mantenimiento
    )
        : base(id)
    {
        Titulo = titulo;
        Autor = autor;
        Editorial = editorial;
        Precio = precio;
        Publicacion = publicacion;
        Categoria = categoria;
        FechaUltimaPrestamo = fechaUltimaPrestamo;
        Mantenimiento = mantenimiento;
    }

    public Titulo Titulo { get; private set; }
    public Autor? Autor { get; private set; }
    public Editorial? Editorial { get; private set; }
    public Moneda? Precio { get; private set; }
    public Publicacion? Publicacion { get; internal set; }
    public Categoria Categoria { get; internal set; }
    public Guid EstanteId { get; internal set; }
    public DateTime? FechaUltimaPrestamo { get; private set; }
    public Moneda? Mantenimiento { get; private set; }
}
