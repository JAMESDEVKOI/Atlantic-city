using GestionBiblioteca.Domain.Abstractions;
using GestionBiblioteca.Domain.Estantes;

public sealed class Estante : Entity
{
    private Estante() { }

    public Estante(Guid id, Ubicacion ubicacion)
        : base(id)
    {
        Ubicacion = ubicacion;
    }

    public Ubicacion Ubicacion { get; private set; }
}
