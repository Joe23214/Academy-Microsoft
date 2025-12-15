using Server.Models;

namespace Server.Repositories
{
    public interface IDocenteRepository
    {
        List<Docente> GetAll();
        Docente? GetById(int id);
        void Add(Docente entity);
        void Update(Docente entity);
        void Delete(Docente entity);
        void Save();
    }
}
