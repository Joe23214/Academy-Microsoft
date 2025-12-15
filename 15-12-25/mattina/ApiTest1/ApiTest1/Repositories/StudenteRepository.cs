using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Repositories
{
    public class StudenteRepository : IStudenteRepository
    {


            protected readonly ScuolaContext _ctx;
            protected readonly DbSet<Studente> _set;

            public StudenteRepository(ScuolaContext ctx)
            {
                _ctx = ctx;
                _set = ctx.Set<Studente>();
            }

            public List<Studente> GetAll() => _set.ToList();
            public Studente? GetById(int id) => _set.Find(id);
            public void Add(Studente entity) => _set.Add(entity);
            public void Update(Studente entity) => _set.Update(entity);
            public void Delete(Studente entity) => _set.Remove(entity);
            public void Save() => _ctx.SaveChanges();

        
    }
}
