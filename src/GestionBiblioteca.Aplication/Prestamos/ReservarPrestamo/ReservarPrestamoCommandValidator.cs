using FluentValidation;


namespace GestionBiblioteca.Aplication.Prestamos.ReservarPrestamo;

public class ReservarPrestamoCommandValidator : AbstractValidator<ReservarPrestamoCommand>
{
    public ReservarPrestamoCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.BibliotecarioId).NotEmpty();
        RuleFor(x => x.FechaInicio).LessThan(c => c.FechaFin);
    }
}
