using GestionBiblioteca.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionBiblioteca.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);

        builder
            .Property(user => user.Nombre)
            .HasMaxLength(200)
            .HasConversion(nombre => nombre!.Value, value => new Nombre(value));

        builder
            .Property(user => user.Apellido)
            .HasMaxLength(200)
            .HasConversion(apellidos => apellidos!.Value, value => new Apellido(value));
        builder
            .Property(user => user.Email)
            .HasMaxLength(400)
            .HasConversion(
                email => email!.Value,
                value => new GestionBiblioteca.Domain.Usuarios.Email(value)
            );

        builder
            .Property(user => user.NumeroDocumento)
            .HasMaxLength(200)
            .HasConversion(
                numeroDocumento => numeroDocumento!.Value,
                value => new GestionBiblioteca.Domain.Usuarios.NumeroDocumento(value)
            );

        builder
            .Property(user => user.Telefono)
            .HasMaxLength(200)
            .HasConversion(
                telefono => telefono!.Value,
                value => new GestionBiblioteca.Domain.Usuarios.Telefono(value)
            );

        builder
            .Property(user => user.Direccion)
            .HasMaxLength(200)
            .HasConversion(
                direccion => direccion!.Value,
                value => new GestionBiblioteca.Domain.Usuarios.Direccion(value)
            );

        builder
            .Property(user => user.Ubigeo)
            .HasMaxLength(200)
            .HasConversion(
                ubigeo => ubigeo!.Value,
                value => new GestionBiblioteca.Domain.Usuarios.Ubigeo(value)
            );

        builder.HasIndex(user => user.Email).IsUnique();
    }
}
