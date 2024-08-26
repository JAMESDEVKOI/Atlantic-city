using CleanArchitecture.Domain.Vehiculos;
using GestionBiblioteca.Aplication.Abstractions.Clock;
using GestionBiblioteca.Aplication.Abstractions.Messaging;
using GestionBiblioteca.Domain.Abstractions;
using GestionBiblioteca.Domain.Libros;
using GestionBiblioteca.Domain.Prestamos;
using GestionBiblioteca.Domain.Usuarios;

namespace GestionBiblioteca.Aplication.Prestamos.ReservarPrestamo;

internal sealed class ReservarPrestamoCommandHandler
    : ICommandHandler<ReservarPrestamoCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly ILibroRepository _libroRepository;
    private readonly IBibliotecarioRepository _bibliotecarioRepository;
    private readonly IPrestamoRepository _PrestamoRepository;
    private readonly PrecioService _precioService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public ReservarPrestamoCommandHandler(
        IUserRepository userRepository,
        ILibroRepository libroRepository,
        IBibliotecarioRepository bibliotecarioRepository,
        IPrestamoRepository prestamoRepository,
        PrecioService precioService,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider
    )
    {
        _userRepository = userRepository;
        _libroRepository = libroRepository;
        _bibliotecarioRepository = bibliotecarioRepository;
        _PrestamoRepository = prestamoRepository;
        _precioService = precioService;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(
        ReservarPrestamoCommand request,
        CancellationToken cancellationToken
    )
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var bibliotecario = await _bibliotecarioRepository.GetByIdAsync(
            request.BibliotecarioId,
            cancellationToken
        );

        if (bibliotecario is null)
        {
            return Result.Failure<Guid>(BibliotecarioErrors.NotFound);
        }

        var duracion = DateRage.Create(request.FechaInicio, request.FechaFin);
        // Implementation of Check if there is overlap
        return Result.Success(Guid.NewGuid());
    }
}
