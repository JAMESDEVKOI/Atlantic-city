using GestionBiblioteca.Domain.Abstractions;

namespace GestionBiblioteca.Domain.Usuarios;

public static class UserErrors
{
    public static Error NotFound = new("User.NotFound", "No existe el usuario por este id");
    public static Error InvalidCredentials =
        new("User.InvalidCredentials", "Las credenciales son invalidas");
}
