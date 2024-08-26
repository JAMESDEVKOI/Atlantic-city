using GestionBiblioteca.Aplication.Abstractions.Clock;

namespace GestionBiblioteca.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime currentTime => DateTime.UtcNow;
}
