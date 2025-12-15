using Server.Models;

namespace Server.Repositories
{
    public interface ICorsoRepository
    {

        List<Corso> GetAll();
        Corso? GetById(int id);
        void Add(Corso entity);
        void Update(Corso entity);
        void Delete(Corso entity);
        void Save();
        Task<Corso?> GetByIdWithRelationsAsync(int id);
        Task<List<Corso>> GetAllWithRelationsAsync();
    }
}
