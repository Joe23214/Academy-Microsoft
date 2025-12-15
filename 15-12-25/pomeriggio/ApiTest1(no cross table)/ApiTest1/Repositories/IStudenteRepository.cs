using Server.Models;

namespace Server.Repositories
{
    public interface IStudenteRepository
    {
        List<Studente> GetAll();
        Studente? GetById(int id);
        void Add(Studente entity);
        void Update(Studente entity);
        void Delete(Studente entity);
        void Save();
        Task<Studente?> GetByIdWithRelationsAsync(int id);
    }
}
