using GestionBiblioteca.Domain.Libros;
using GestionBiblioteca.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionBiblioteca.Infrastructure.Configurations;

internal sealed class LibroConfiguration : IEntityTypeConfiguration<Libro>
{
    public void Configure(EntityTypeBuilder<Libro> builder)
    {
        builder.ToTable("libros");

        builder.HasKey(libro => libro.Id);
        builder.HasOne<Estante>().WithMany().HasForeignKey(Prestamo => Prestamo.EstanteId);

        builder
            .Property(libro => libro.Titulo)
            .HasMaxLength(200)
            .HasConversion(titulo => titulo!.Value, value => new Titulo(value));

        builder
            .Property(libro => libro.Autor)
            .HasMaxLength(200)
            .HasConversion(titulo => titulo!.Value, value => new Autor(value));
        builder
            .Property(libro => libro.Editorial)
            .HasMaxLength(200)
            .HasConversion(titulo => titulo!.Value, value => new Editorial(value));

        builder
            .Property(libro => libro.Publicacion)
            .HasMaxLength(200)
            .HasConversion(titulo => titulo!.Value, value => new Publicacion(value));
        builder
            .Property(libro => libro.Categoria)
            .HasMaxLength(200)
            .HasConversion(titulo => titulo!.Value, value => new Categoria(value));

        builder.OwnsOne(
            vehiculo => vehiculo.Precio,
            priceBuilder =>
            {
                priceBuilder
                    .Property(moneda => moneda.TipoMoneda)
                    .HasConversion(
                        tipoMoneda => tipoMoneda.Codigo,
                        codigo => TipoMoneda.FromCodigo(codigo!)
                    );
            }
        );
        builder.OwnsOne(
            vehiculo => vehiculo.Mantenimiento,
            priceBuilder =>
            {
                priceBuilder
                    .Property(moneda => moneda.TipoMoneda)
                    .HasConversion(
                        tipoMoneda => tipoMoneda.Codigo,
                        codigo => TipoMoneda.FromCodigo(codigo!)
                    );
            }
        );

        builder.Property<uint>("Version").IsRowVersion();
    }
}
