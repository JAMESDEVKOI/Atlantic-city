namespace GestionBiblioteca.Aplication.Abstractions.Clock;

public interface IDateTimeProvider
{
    DateTime currentTime { get; }
}
