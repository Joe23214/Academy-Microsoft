using ScuolaAPIServer.Data;
using ScuolaAPIServer.Models;

namespace ScuolaAPIServer.Repositories
{
    public class CorsoRepository : GenericRepository<Corso>, ICorsoRepository
    {
        public CorsoRepository(ScuolaDbContext ctx) : base(ctx) { }
    }
}