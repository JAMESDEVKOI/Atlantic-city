using GestionBiblioteca.Domain.Prestamos;
using GestionBiblioteca.Domain.Prestamos.Events;
using GestionBiblioteca.Domain.Usuarios;
using MediatR;

namespace CleanArchitecture.Application.Prestamoes.ReservarPrestamo;

internal sealed class ReservarPrestamoDomainEventHandler
    : INotificationHandler<PrestamoReservadoDomainEvent>
{
    private readonly IPrestamoRepository _prestamoRepository;
    private readonly IUserRepository _userRepository;

    public ReservarPrestamoDomainEventHandler(
        IPrestamoRepository PrestamoRepository,
        IUserRepository userRepository
    )
    {
        _prestamoRepository = PrestamoRepository;
        _userRepository = userRepository;
    }

    public async Task Handle(
        PrestamoReservadoDomainEvent notification,
        CancellationToken cancellationToken
    )
    {
        var Prestamo = await _prestamoRepository.GetByIdAsync(
            notification.PrestamoId,
            cancellationToken
        );
        if (Prestamo is null)
            return;
        var user = await _userRepository.GetByIdAsync(Prestamo.UserId, cancellationToken);
        if (user is null)
            return;
    }
}
