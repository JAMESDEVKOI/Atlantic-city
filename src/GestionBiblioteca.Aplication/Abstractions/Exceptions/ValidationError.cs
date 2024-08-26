namespace GestionBiblioteca.Aplication.Abstractions.Exceptions;

public sealed record ValidationError(string PropertyName, string ErrorMessage);
