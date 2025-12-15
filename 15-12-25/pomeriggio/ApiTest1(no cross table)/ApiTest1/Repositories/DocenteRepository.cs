using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Repositories
{
    public class DocenteRepository : IDocenteRepository
    {

       
            protected readonly ScuolaContext _ctx;
            protected readonly DbSet<Docente> _set;

            public DocenteRepository(ScuolaContext ctx)
            {
                _ctx = ctx;
                _set = ctx.Set<Docente>();
            }

            public List<Docente> GetAll() => _set.ToList();
            public Docente? GetById(int id) => _set.Find(id);
            public void Add(Docente entity) => _set.Add(entity);
            public void Update(Docente entity) => _set.Update(entity);
            public void Delete(Docente entity) => _set.Remove(entity);
            public void Save() => _ctx.SaveChanges();

        public async Task<Docente?> GetByIdWithRelationsAsync(int id)
        {
            return await _ctx.Docenti
                .Include(d => d.corsi)
                .FirstOrDefaultAsync(d => d.Id == id);
        }


    }
}
