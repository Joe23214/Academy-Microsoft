using EfDemo.Data;
using EfDemo.Models;
using EfDemo.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfDemo.Controller
{
    public class DocenteController
    {
        private readonly IDocenteRepository _repo = new DocenteRepository(new ScuolaContext());

        public void InserisciDocente(Docente d) => _repo.Add(d);
        public IQueryable<Docente> GetDocenti() => _repo.GetAll();
        public Docente? GetDocenteById(int id) => _repo.GetById(id);
        public void ModificaDocente(Docente d) => _repo.Update(d);
        public void EliminaDocente(Docente d) => _repo.Delete(d);

        public void AssegnaCorso(Docente d, Corso c) => _repo.AssegnaCorso(d, c);
        public void RimuoviCorso(Docente d, Corso c) => _repo.RimuoviCorso(d, c);
    }

}
