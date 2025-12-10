using EfDemo.Data;
using EfDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfDemo.Controller
{
    public class DocenteController
    {
        public void InserisciDocente(Docente docente)
        {
            using var db = new ScuolaContext();
            db.Docenti.Add(docente);
            db.SaveChanges();
        }

        public IQueryable<Docente> GetDocenti()
        {
            var db = new ScuolaContext();
            return db.Docenti.OrderBy(d => d.Name);
        }

        public Docente? GetDocenteById(int id)
        {
            using var db = new ScuolaContext();
            return db.Docenti.FirstOrDefault(d => d.Id == id);
        }

        public void ModificaDocente(Docente docente)
        {
            using var db = new ScuolaContext();
            var d = db.Docenti.FirstOrDefault(x => x.Id == docente.Id);
            if (d != null)
            {
                d.Name = docente.Name;
                db.SaveChanges();
            }
        }

        public void EliminaDocente(Docente docente)
        {
            using var db = new ScuolaContext();
            db.Docenti.Remove(docente);
            db.SaveChanges();
        }

        // RELAZIONI
        public void AssegnaCorso(Docente docente, Corso corso)
        {
            using var db = new ScuolaContext();
            var d = db.Docenti.Include(x => x.corsi).FirstOrDefault(x => x.Id == docente.Id);
            var c = db.Corsi.Find(corso.Id);
            if (d != null && c != null && !d.corsi.Contains(c))
            {
                d.corsi.Add(c);
                db.SaveChanges();
            }
        }

        public void RimuoviCorso(Docente docente, Corso corso)
        {
            using var db = new ScuolaContext();
            var d = db.Docenti.Include(x => x.corsi).FirstOrDefault(x => x.Id == docente.Id);
            if (d != null)
            {
                var c = d.corsi.FirstOrDefault(x => x.Id == corso.Id);
                if (c != null)
                {
                    d.corsi.Remove(c);
                    db.SaveChanges();
                }
            }
        }
    }
}
