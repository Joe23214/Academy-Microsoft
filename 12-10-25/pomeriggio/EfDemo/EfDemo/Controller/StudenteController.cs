using EfDemo.Data;
using EfDemo.Models;
using EfDemo.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfDemo.Controller
{
    public class StudenteController
    {
        private readonly IStudenteRepository _repo = new StudenteRepository(new ScuolaContext());

        public void InserisciStudente(Studente s) => _repo.Add(s);
        public IQueryable<Studente> GetStudenti() => _repo.GetAll();
        public Studente? GetStudenteById(int id) => _repo.GetById(id);
        public void ModificaStudente(Studente s) => _repo.Update(s);
        public void EliminaStudente(Studente s) => _repo.Delete(s);

        public void AssegnaCorso(Studente s, Corso c) => _repo.AssegnaCorso(s, c);
        public void RimuoviCorso(Studente s, Corso c) => _repo.RimuoviCorso(s, c);
    }

}
