using GestionBiblioteca.Domain.Abstractions;
using GestionBiblioteca.Domain.Libros;
using GestionBiblioteca.Domain.Prestamos.Events;
using GestionBiblioteca.Domain.Shared;

namespace GestionBiblioteca.Domain.Prestamos;

public sealed class Prestamo : Entity
{
    public Prestamo() { }

    private Prestamo(
        Guid id,
        Guid bibliotecarioId,
        Guid userId,
        Moneda moneda,
        PrestamoStatus estado,
        DateTime fechaPrestamo,
        Moneda mantenimiento,
        DateRage duracion,
        Moneda precioPorPeriodo
    )
        : base(id)
    {
        BibliotecarioId = bibliotecarioId;
        UserId = userId;
        PrecioTotal = moneda;
        Estado = estado;
        FechaPrestamo = fechaPrestamo;
        Mantenimiento = mantenimiento;
        Duracion = duracion;
        PrecioPorPeriodo = precioPorPeriodo;
    }

    public Guid BibliotecarioId { get; private set; }
    public Guid UserId { get; private set; }
    public Moneda? PrecioPorPeriodo { get; private set; }
    public Moneda? PrecioTotal { get; private set; }
    public PrestamoStatus Estado { get; private set; }
    public DateTime? FechaPrestamo { get; private set; }
    public DateTime? FechaConfirmacion { get; private set; }
    public DateTime? FechaDenegacion { get; private set; }
    public DateTime? FechaCompletado { get; private set; }
    public DateTime? FechaCancelacion { get; private set; }
    public Moneda? Mantenimiento { get; private set; }
    public DateRage? Duracion { get; private set; }

    public static Prestamo Reservar(
        Libro libro,
        Guid userId,
        DateRage duracion,
        DateTime fechaCreacion,
        PrecioService precioService
    )
    {
        var precioDetalle = precioService.CalcularPrecio(libro, duracion);

        var prestamo = new Prestamo(
            Guid.NewGuid(),
            libro.Id,
            userId,
            precioDetalle.precioTotal,
            PrestamoStatus.Reservado,
            fechaCreacion,
            precioDetalle.mantenimiento,
            duracion,
            precioDetalle.precioPorPeriodo
        );
        prestamo.RaiseDomainEvent(new PrestamoReservadoDomainEvent(prestamo.Id!));

        return prestamo;
    }

    public Result Confirmar(DateTime utcNow)
    {
        if (Estado != PrestamoStatus.Reservado)
        {
            return Result.Failure(PrestamoErrors.NotReserved);
        }

        Estado = PrestamoStatus.Confirmado;
        FechaPrestamo = utcNow;

        RaiseDomainEvent(new PrestamoConfirmadoDomainEvent(Id!));

        return Result.Success();
    }

    public Result Rechazar(DateTime utcNow)
    {
        if (Estado != PrestamoStatus.Reservado)
        {
            return Result.Failure(PrestamoErrors.NotReserved);
        }

        Estado = PrestamoStatus.Rechazado;
        FechaDenegacion = utcNow;

        RaiseDomainEvent(new PrestamoRechazadoDomainEvent(Id!));

        return Result.Success();
    }

    public Result Cancelar(DateTime utcNow)
    {
        if (Estado != PrestamoStatus.Confirmado)
        {
            return Result.Failure(PrestamoErrors.NotConfirmado);
        }

        var currentDate = DateOnly.FromDateTime(utcNow);

        if (currentDate > Duracion!.Inicio)
        {
            return Result.Failure(PrestamoErrors.AlreadyStatus);
        }

        Estado = PrestamoStatus.Cancelado;
        FechaCancelacion = utcNow;
        RaiseDomainEvent(new PrestamoCanceladoDomainEvent(Id));

        return Result.Success();
    }

    public Result Completar(DateTime utcNow)
    {
        if (Estado != PrestamoStatus.Confirmado)
        {
            return Result.Failure(PrestamoErrors.NotConfirmado);
        }
        Estado = PrestamoStatus.Completado;
        FechaCompletado = utcNow;
        RaiseDomainEvent(new PrestamoCompletadoDomainEvent(Id!));

        return Result.Success();
    }
}
