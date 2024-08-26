using GestionBiblioteca.Domain.Abstractions;
using GestionBiblioteca.Domain.Bibliotecarios.Events;

namespace GestionBiblioteca.Domain.Bibliotecarios;

public sealed class Bibliotecario : Entity
{
    private Bibliotecario() { }

    public Bibliotecario(
        Guid id,
        Nombre nombre,
        Apellido apellido,
        NumeroDocumento numeroDocumento,
        Telefono telefono,
        Email email
    )
        : base(id)
    {
        Nombre = nombre;
        Apellido = apellido;
        NumeroDocumento = numeroDocumento;
        Telefono = telefono;
        Email = email;
    }

    public Nombre Nombre { get; private set; }
    public Apellido Apellido { get; private set; }
    public NumeroDocumento NumeroDocumento { get; private set; }
    public Telefono Telefono { get; private set; }
    public Email? Email { get; private set; }

    public static Bibliotecario Create(
        Nombre nombre,
        Apellido apellido,
        NumeroDocumento numeroDocumento,
        Telefono telefono,
        Email email
    )
    {
        var user = new Bibliotecario(
            Guid.NewGuid(),
            nombre,
            apellido,
            numeroDocumento,
            telefono,
            email
        );

        user.RaiseDomainEvent(new BibliotecarioCreateDomainEvent(user.Id));

        return user;
    }
}
