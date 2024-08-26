using GestionBiblioteca.Domain.Libros;

namespace GestionBiblioteca.Infrastructure.Repositories;

internal sealed class LibroRepository : Repository<Libro>, ILibroRepository
{
    public LibroRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }
}
