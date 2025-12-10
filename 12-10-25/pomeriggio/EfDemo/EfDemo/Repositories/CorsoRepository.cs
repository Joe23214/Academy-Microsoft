using EfDemo.Data;
using EfDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfDemo.Repositories
{
    public class CorsoRepository : ICorsoRepository
    {
        private readonly ScuolaContext _db;

        public CorsoRepository(ScuolaContext db)
        {
            _db = db;
        }

        public IQueryable<Corso> GetAll()
            => _db.Corsi.OrderBy(c => c.Titolo);

        public Corso? GetById(int id)
            => _db.Corsi.FirstOrDefault(c => c.Id == id);

        public void Add(Corso corso)
        {
            _db.Corsi.Add(corso);
            Save();
        }

        public void Update(Corso corso)
        {
            var c = _db.Corsi.FirstOrDefault(x => x.Id == corso.Id);
            if (c == null) return;

            c.Titolo = corso.Titolo;
            c.codiceCorso = corso.codiceCorso;

            Save();
        }

        public void Delete(Corso corso)
        {
            _db.Corsi.Remove(corso);
            Save();
        }

        // ---------------------------
        // RELAZIONI
        // ---------------------------

        public void AssegnaDocente(Corso corso, Docente docente)
        {
            var c = _db.Corsi.Include(x => x.Docenti).FirstOrDefault(x => x.Id == corso.Id);
            var d = _db.Docenti.Find(docente.Id);

            if (c != null && d != null && !c.Docenti.Contains(d))
            {
                c.Docenti.Add(d);
                Save();
            }
        }

        public void AssegnaStudente(Corso corso, Studente studente)
        {
            var c = _db.Corsi.Include(x => x.studenti).FirstOrDefault(x => x.Id == corso.Id);
            var s = _db.Studenti.Find(studente.Id);

            if (c != null && s != null && !c.studenti.Contains(s))
            {
                c.studenti.Add(s);
                Save();
            }
        }

        public void Save() => _db.SaveChanges();
    }
}
