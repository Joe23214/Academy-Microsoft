using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Repositories
{
    public class CorsoRepository : ICorsoRepository
    {


            protected readonly ScuolaContext _ctx;
            protected readonly DbSet<Corso> _set;

            public CorsoRepository(ScuolaContext ctx)
            {
                _ctx = ctx;
                _set = ctx.Set<Corso>();
            }

            public List<Corso> GetAll() => _set.ToList();
            public Corso? GetById(int id) => _set.Find(id);
            public void Add(Corso entity) => _set.Add(entity);
            public void Update(Corso entity) => _set.Update(entity);
            public void Delete(Corso entity) => _set.Remove(entity);
            public void Save() => _ctx.SaveChanges();

            public async Task<Corso?> GetByIdWithRelationsAsync(int id)
            {
                return await _ctx.Corsi
                    .Include(c => c.studenti)
                    .Include(c => c.Docenti)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }

            public async Task<List<Corso>> GetAllWithRelationsAsync()
            {
                return await _ctx.Corsi
                    .Include(c => c.studenti)
                    .Include(c => c.Docenti)
                    .ToListAsync();
            }
    }
}
