using EfDemo.Data;
using EfDemo.Models;
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
            return db.Studenti.SingleOrDefault(s => s.Id == id);
        }

        public void ModificaStudente(Studente studenteAggiornato)
        {
            using var db = new ScuolaContext();
            var stud = db.Studenti.SingleOrDefault(s => s.Id == studenteAggiornato.Id);
            if (stud != null)
            {
                stud.Nome = studenteAggiornato.Nome;
                stud.Cognome = studenteAggiornato.Cognome;
                stud.Eta = studenteAggiornato.Eta;
                stud.Matricola = studenteAggiornato.Matricola;
                stud.IdCorso = studenteAggiornato.IdCorso;

                db.SaveChanges();
            }
        }

        public void EliminaStudente(int id)
        {
            using var db = new ScuolaContext();
            var stud = db.Studenti.FirstOrDefault(s => s.Id == id);

            if (stud != null)
            {
                db.Studenti.Remove(stud);
                db.SaveChanges();
            }
        }
    }
}
