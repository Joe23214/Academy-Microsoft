using Microsoft.EntityFrameworkCore;
using ScuolaAPIServer.Data;

namespace ScuolaAPIServer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ScuolaDbContext _ctx;
        protected readonly DbSet<T> _set;

        public GenericRepository(ScuolaDbContext ctx)
        {
            _ctx = ctx;
            _set = ctx.Set<T>();
        }

        public List<T> GetAll() => _set.ToList();
        public T? GetById(int id) => _set.Find(id);
        public void Add(T entity) => _set.Add(entity);
        public void Update(T entity) => _set.Update(entity);
        public void Delete(T entity) => _set.Remove(entity);
        public void Save() => _ctx.SaveChanges();
    }
}
