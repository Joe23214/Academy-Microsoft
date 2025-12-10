using EfDemo.Data;
using EfDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfDemo.Controller
{
    public class StudenteController
    {
        public void InserisciStudente(Studente studente)
        {
            using var db = new ScuolaContext();
            db.Studenti.Add(studente);
            db.SaveChanges();
        }

        public IQueryable<Studente> GetStudenti()
        {
            var db = new ScuolaContext();
            return db.Studenti.OrderBy(s => s.Cognome);
        }

        public Studente? GetStudenteById(int id)
        {
            using var db = new ScuolaContext();
            return db.Studenti.FirstOrDefault(s => s.Id == id);
        }

        public void ModificaStudente(Studente studente)
        {
            using var db = new ScuolaContext();
            var s = db.Studenti.FirstOrDefault(x => x.Id == studente.Id);
            if (s != null)
            {
                s.Nome = studente.Nome;
                s.Cognome = studente.Cognome;
                s.Eta = studente.Eta;
                s.Matricola = studente.Matricola;
                db.SaveChanges();
            }
        }

        public void EliminaStudente(Studente studente)
        {
            using var db = new ScuolaContext();
            db.Studenti.Remove(studente);
            db.SaveChanges();
        }

        // RELAZIONI
        public void AssegnaCorso(Studente studente, Corso corso)
        {
            using var db = new ScuolaContext();
            var s = db.Studenti.Include(x => x.Corsi).FirstOrDefault(x => x.Id == studente.Id);
            var c = db.Corsi.Find(corso.Id);
            if (s != null && c != null && !s.Corsi.Contains(c))
            {
                s.Corsi.Add(c);
                db.SaveChanges();
            }
        }

        public void RimuoviCorso(Studente studente, Corso corso)
        {
            using var db = new ScuolaContext();
            var s = db.Studenti.Include(x => x.Corsi).FirstOrDefault(x => x.Id == studente.Id);
            if (s != null)
            {
                var c = s.Corsi.FirstOrDefault(x => x.Id == corso.Id);
                if (c != null)
                {
                    s.Corsi.Remove(c);
                    db.SaveChanges();
                }
            }
        }
    }
}
