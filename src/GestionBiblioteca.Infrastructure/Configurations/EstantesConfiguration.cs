using GestionBiblioteca.Domain.Copias;
using GestionBiblioteca.Domain.Estantes;
using GestionBiblioteca.Domain.Libros;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionBiblioteca.Infrastructure.Configurations;

internal sealed class EstanteConfiguration : IEntityTypeConfiguration<Estante>
{
    public void Configure(EntityTypeBuilder<Estante> builder)
    {
        builder.ToTable("estantes");

        builder.HasKey(estante => estante.Id);

        builder
            .Property(estante => estante.Ubicacion)
            .HasMaxLength(200)
            .HasConversion(copia => copia!.Value, value => new Ubicacion(value));

        builder.Property<uint>("Version").IsRowVersion();
    }
}
