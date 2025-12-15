using ScuolaAPIServer.Data;
using ScuolaAPIServer.Models;



namespace ScuolaAPIServer.Repositories
{
    public class ProfessoreRepository : GenericRepository<Professore>, IProfessoreRepository
    {
        public ProfessoreRepository(ScuolaDbContext ctx) : base(ctx) { }
    }
}