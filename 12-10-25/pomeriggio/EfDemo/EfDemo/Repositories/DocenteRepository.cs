using EfDemo.Data;
using EfDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfDemo.Repositories
{
    public class DocenteRepository : IDocenteRepository
    {
        private readonly ScuolaContext _db;

        public DocenteRepository(ScuolaContext db)
        {
            _db = db;
        }

        public IQueryable<Docente> GetAll()
            => _db.Docenti.OrderBy(d => d.Name);

        public Docente? GetById(int id)
            => _db.Docenti.FirstOrDefault(d => d.Id == id);

        public void Add(Docente docente)
        {
            _db.Docenti.Add(docente);
            Save();
        }

        public void Update(Docente docente)
        {
            var d = _db.Docenti.FirstOrDefault(x => x.Id == docente.Id);
            if (d == null) return;

            d.Name = docente.Name;
            Save();
        }

        public void Delete(Docente docente)
        {
            _db.Docenti.Remove(docente);
            Save();
        }

        // ---------------------------
        // RELAZIONI
        // ---------------------------

        public void AssegnaCorso(Docente docente, Corso corso)
        {
            var d = _db.Docenti.Include(x => x.corsi).FirstOrDefault(x => x.Id == docente.Id);
            var c = _db.Corsi.Find(corso.Id);

            if (d != null && c != null && !d.corsi.Contains(c))
            {
                d.corsi.Add(c);
                Save();
            }
        }

        public void RimuoviCorso(Docente docente, Corso corso)
        {
            var d = _db.Docenti.Include(x => x.corsi).FirstOrDefault(x => x.Id == docente.Id);
            var c = d?.corsi.FirstOrDefault(x => x.Id == corso.Id);

            if (d != null && c != null)
            {
                d.corsi.Remove(c);
                Save();
            }
        }

        public void Save() => _db.SaveChanges();
    }
}
