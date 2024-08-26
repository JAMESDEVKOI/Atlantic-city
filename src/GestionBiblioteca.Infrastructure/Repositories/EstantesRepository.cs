using GestionBiblioteca.Domain.Estantes;

namespace GestionBiblioteca.Infrastructure.Repositories;

internal sealed class EstanteRepository : Repository<Estante>, IEstanteRepository
{
    public EstanteRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }
}
