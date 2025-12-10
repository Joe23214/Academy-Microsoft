using EfDemo.Data;
using EfDemo.Models;
using EfDemo.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfDemo.Controller
{
    public class CorsoController
    {
        private readonly ICorsoRepository _repo = new CorsoRepository(new ScuolaContext());

        public void InserisciCorso(Corso c) => _repo.Add(c);
        public IQueryable<Corso> GetCorsi() => _repo.GetAll();
        public Corso? GetCorsoById(int id) => _repo.GetById(id);
        public void ModificaCorso(Corso c) => _repo.Update(c);
        public void EliminaCorso(Corso c) => _repo.Delete(c);

        public void AssegnaDocente(Corso c, Docente d) => _repo.AssegnaDocente(c, d);
        public void AssegnaStudente(Corso c, Studente s) => _repo.AssegnaStudente(c, s);
    }

}

