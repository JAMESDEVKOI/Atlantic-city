using GestionBiblioteca.Domain.Bibliotecarios;
using GestionBiblioteca.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionBiblioteca.Infrastructure.Configurations;

internal sealed class BibliotecarioConfiguration : IEntityTypeConfiguration<Bibliotecario>
{
    public void Configure(EntityTypeBuilder<Bibliotecario> builder)
    {
        builder.ToTable("bibliotecarios");

        builder.HasKey(bibliotecario => bibliotecario.Id);

        builder
            .Property(bibliotecario => bibliotecario.Nombre)
            .HasMaxLength(200)
            .HasConversion(
                nombre => nombre!.Value,
                value => new Domain.Bibliotecarios.Nombre(value)
            );

        builder
            .Property(bibliotecario => bibliotecario.Apellido)
            .HasMaxLength(200)
            .HasConversion(
                apellidos => apellidos!.Value,
                value => new Domain.Bibliotecarios.Apellido(value)
            );
        builder
            .Property(bibliotecario => bibliotecario.NumeroDocumento)
            .HasMaxLength(400)
            .HasConversion(
                email => email!.Value,
                value => new Domain.Bibliotecarios.NumeroDocumento(value)
            );

        builder
            .Property(bibliotecario => bibliotecario.Telefono)
            .HasMaxLength(200)
            .HasConversion(
                telefono => telefono!.Value,
                value => new Domain.Bibliotecarios.Telefono(value)
            );

        builder
            .Property(user => user.Email)
            .HasMaxLength(400)
            .HasConversion(email => email!.Value, value => new Domain.Bibliotecarios.Email(value));

        builder.HasIndex(bibliotecario => bibliotecario.Email).IsUnique();
    }
}
