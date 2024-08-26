using GestionBiblioteca.Domain.Abstractions;

namespace GestionBiblioteca.Domain.Copias;

public sealed class Copia : Entity
{
    private Copia() { }

    public Copia(Guid id, CodigoBarras codigoBarras, Guid libroId)
        : base(id)
    {
        CodigoBarras = codigoBarras;
        LibroId = libroId;
    }

    public CodigoBarras CodigoBarras { get; private set; }
    public Guid LibroId { get; private set; }
}
