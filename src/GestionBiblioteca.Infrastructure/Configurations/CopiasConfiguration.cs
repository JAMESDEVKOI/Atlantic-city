using GestionBiblioteca.Domain.Copias;
using GestionBiblioteca.Domain.Libros;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionBiblioteca.Infrastructure.Configurations;

internal sealed class CopiasConfiguration : IEntityTypeConfiguration<Copia>
{
    public void Configure(EntityTypeBuilder<Copia> builder)
    {
        builder.ToTable("copia");

        builder.HasKey(copia => copia.Id);
        builder.HasOne<Libro>().WithMany().HasForeignKey(copia => copia.LibroId);

        builder
            .Property(copia => copia.CodigoBarras)
            .HasMaxLength(200)
            .HasConversion(copia => copia!.Value, value => new CodigoBarras(value));

        builder.Property<uint>("Version").IsRowVersion();
    }
}
