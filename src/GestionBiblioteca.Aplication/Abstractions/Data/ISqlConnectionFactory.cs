using System.Data;

namespace GestionBiblioteca.Aplication.Abstractions.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
