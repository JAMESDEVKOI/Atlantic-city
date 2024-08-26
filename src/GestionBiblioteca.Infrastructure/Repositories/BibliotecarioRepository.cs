using CleanArchitecture.Domain.Vehiculos;
using GestionBiblioteca.Domain.Bibliotecarios;

namespace GestionBiblioteca.Infrastructure.Repositories;

internal sealed class BibliotecarioRepository : Repository<Bibliotecario>, IBibliotecarioRepository
{
    public BibliotecarioRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }
}
