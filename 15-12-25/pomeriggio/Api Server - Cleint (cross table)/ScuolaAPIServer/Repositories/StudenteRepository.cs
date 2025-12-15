using ScuolaAPIServer.Data;
using ScuolaAPIServer.Models;


namespace ScuolaAPIServer.Repositories
{
    public class StudenteRepository : GenericRepository<Studente>, IStudenteRepository
    {
        public StudenteRepository(ScuolaDbContext ctx) : base(ctx) { }
    }
}