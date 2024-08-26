using GestionBiblioteca.Domain.Abstractions;

using GestionBiblioteca.Domain.Usuarios.Events;

namespace GestionBiblioteca.Domain.Usuarios
{
    public sealed class User : Entity
    {
        private User() { }

        private User(
            Guid id,
            Nombre nombre,
            Apellido apellido,
            Email email,
            NumeroDocumento numeroDocumento,
            Telefono telefono,
            Direccion direccion,
            Ubigeo ubigeo
        )
            : base(id)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            NumeroDocumento = numeroDocumento;
            Telefono = telefono;
            Direccion = direccion;
            Ubigeo = ubigeo;
        }

        public Nombre? Nombre { get; private set; }
        public Apellido? Apellido { get; private set; }
        public Email? Email { get; private set; }
        public NumeroDocumento NumeroDocumento { get; private set; }
        public Telefono Telefono { get; private set; }
        public Direccion Direccion { get; private set; }
        public Ubigeo Ubigeo { get; private set; }

        public static User Create(
            Nombre nombre,
            Apellido apellido,
            Email email,
            NumeroDocumento numeroDocumento,
            Telefono telefono,
            Direccion direccion,
            Ubigeo ubigeo
        )
        {
            var user = new User(
                Guid.NewGuid(),
                nombre,
                apellido,
                email,
                numeroDocumento,
                telefono,
                direccion,
                ubigeo
            );

            user.RaiseDomainEvent(new UserCreateDomainEvent(user.Id));

            return user;
        }
    }
}
