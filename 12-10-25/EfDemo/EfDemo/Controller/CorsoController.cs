using EfDemo.Data;
using EfDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfDemo.Controller
{
    public class CorsoController
    {
        public void InserisciCorso(Corso corso)
        {
            using var db = new ScuolaContext();
            db.Corsi.Add(corso);
            db.SaveChanges();
        }

        public IQueryable<Corso> GetCorsi()
        {
            var db = new ScuolaContext();
            return db.Corsi.OrderBy(c => c.Titolo);
        }

        public Corso? GetCorsoById(int id)
        {
            using var db = new ScuolaContext();
            return db.Corsi.FirstOrDefault(c => c.Id == id);
        }

        public void ModificaCorso(Corso corso)
        {
            using var db = new ScuolaContext();
            var c = db.Corsi.FirstOrDefault(x => x.Id == corso.Id);
            if (c != null)
            {
                c.Titolo = corso.Titolo;
                c.codiceCorso = corso.codiceCorso;
                db.SaveChanges();
            }
        }

        public void EliminaCorso(Corso corso)
        {
            using var db = new ScuolaContext();
            db.Corsi.Remove(corso);
            db.SaveChanges();
        }

        // RELAZIONI
        public void AssegnaDocente(Corso corso, Docente docente)
        {
            using var db = new ScuolaContext();
            var c = db.Corsi.Include(x => x.Docenti).FirstOrDefault(x => x.Id == corso.Id);
            var d = db.Docenti.Find(docente.Id);
            if (c != null && d != null && !c.Docenti.Contains(d))
            {
                c.Docenti.Add(d);
                db.SaveChanges();
            }
        }

        public void AssegnaStudente(Corso corso, Studente studente)
        {
            using var db = new ScuolaContext();
            var c = db.Corsi.Include(x => x.studenti).FirstOrDefault(x => x.Id == corso.Id);
            var s = db.Studenti.Find(studente.Id);
            if (c != null && s != null && !c.studenti.Contains(s))
            {
                c.studenti.Add(s);
                db.SaveChanges();
            }
        }
    }
}
