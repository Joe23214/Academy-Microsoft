using EfDemo.Data;
using EfDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfDemo.Repositories
{
    public class StudenteRepository : IStudenteRepository
    {
        private readonly ScuolaContext _db;

        public StudenteRepository(ScuolaContext db)
        {
            _db = db;
        }

        public IQueryable<Studente> GetAll()
            => _db.Studenti.OrderBy(s => s.Cognome);

        public Studente? GetById(int id)
            => _db.Studenti.FirstOrDefault(s => s.Id == id);

        public void Add(Studente studente)
        {
            _db.Studenti.Add(studente);
            Save();
        }

        public void Update(Studente studente)
        {
            var s = _db.Studenti.FirstOrDefault(x => x.Id == studente.Id);
            if (s == null) return;

            s.Nome = studente.Nome;
            s.Cognome = studente.Cognome;
            s.Eta = studente.Eta;
            s.Matricola = studente.Matricola;

            Save();
        }

        public void Delete(Studente studente)
        {
            _db.Studenti.Remove(studente);
            Save();
        }

        // ---------------------------
        // RELAZIONI
        // ---------------------------

        public void AssegnaCorso(Studente studente, Corso corso)
        {
            var s = _db.Studenti.Include(x => x.Corsi).FirstOrDefault(x => x.Id == studente.Id);
            var c = _db.Corsi.Find(corso.Id);

            if (s != null && c != null && !s.Corsi.Contains(c))
            {
                s.Corsi.Add(c);
                Save();
            }
        }

        public void RimuoviCorso(Studente studente, Corso corso)
        {
            var s = _db.Studenti.Include(x => x.Corsi).FirstOrDefault(x => x.Id == studente.Id);
            var c = s?.Corsi.FirstOrDefault(x => x.Id == corso.Id);

            if (s != null && c != null)
            {
                s.Corsi.Remove(c);
                Save();
            }
        }

        public void Save() => _db.SaveChanges();
    }
}
