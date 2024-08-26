namespace GestionBiblioteca.Domain.Prestamos;


public sealed record DateRage
{
  private DateRage() { }

  public DateOnly Inicio { get; init; }
  public DateOnly Fin { get; init; }

  public int CantidadDias => Fin.DayNumber - Inicio.DayNumber;

  public static DateRage Create(DateOnly inicio, DateOnly fin)
  {
    if (inicio > fin)
    {
      throw new ApplicationException("La fecha final es anterior a la fecha de inicio");
    }

    return new DateRage
    {
      Inicio = inicio,
      Fin = fin
    };
  }
}