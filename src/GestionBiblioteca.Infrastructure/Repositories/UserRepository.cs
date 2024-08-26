using GestionBiblioteca.Domain.Usuarios;

namespace GestionBiblioteca.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }
}
