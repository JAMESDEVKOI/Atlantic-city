using GestionBiblioteca.Domain.Libros;

namespace GestionBiblioteca.Infrastructure.Repositories;

internal sealed class CopiaRepository : Repository<Copia>, ICopiaRepository
{
    public CopiaRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }
}
