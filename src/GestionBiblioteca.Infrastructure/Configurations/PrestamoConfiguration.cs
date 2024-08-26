using GestionBiblioteca.Domain.Bibliotecarios;
using GestionBiblioteca.Domain.Libros;
using GestionBiblioteca.Domain.Prestamos;
using GestionBiblioteca.Domain.Shared;
using GestionBiblioteca.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionBiblioteca.Infrastructure.Configurations;

internal sealed class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo>
{
    public void Configure(EntityTypeBuilder<Prestamo> builder)
    {
        builder.ToTable("prestamos");

        builder.HasKey(Prestamo => Prestamo.Id);

        builder.OwnsOne(
            Prestamo => Prestamo.PrecioPorPeriodo,
            precioBuilder =>
            {
                precioBuilder
                    .Property(moneda => moneda.TipoMoneda)
                    .HasConversion(
                        tipoMoneda => tipoMoneda.Codigo,
                        codigo => TipoMoneda.FromCodigo(codigo!)
                    );
            }
        );
        builder.OwnsOne(
            Prestamo => Prestamo.Mantenimiento,
            precioBuilder =>
            {
                precioBuilder
                    .Property(moneda => moneda.TipoMoneda)
                    .HasConversion(
                        tipoMoneda => tipoMoneda.Codigo,
                        codigo => TipoMoneda.FromCodigo(codigo!)
                    );
            }
        );

        builder.OwnsOne(
            Prestamo => Prestamo.PrecioTotal,
            precioBuilder =>
            {
                precioBuilder
                    .Property(moneda => moneda.TipoMoneda)
                    .HasConversion(
                        tipoMoneda => tipoMoneda.Codigo,
                        codigo => TipoMoneda.FromCodigo(codigo!)
                    );
            }
        );

        builder.OwnsOne(Prestamo => Prestamo.Duracion);
        builder
            .HasOne<Bibliotecario>()
            .WithMany()
            .HasForeignKey(Prestamo => Prestamo.BibliotecarioId);
        builder.HasOne<User>().WithMany().HasForeignKey(Prestamo => Prestamo.UserId);
    }
}
