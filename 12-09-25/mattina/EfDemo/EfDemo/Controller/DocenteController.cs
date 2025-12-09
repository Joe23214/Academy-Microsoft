using EfDemo.Data;
using EfDemo.Models;
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

        public void ModificaDocente(Docente docenteAggiornato)
        {
            using var db = new ScuolaContext();
            var doc = db.Docenti.FirstOrDefault(d => d.Id == docenteAggiornato.Id);

            if (doc != null)
            {
                doc.Name = docenteAggiornato.Name;
                doc.Materia = docenteAggiornato.Materia;

                db.SaveChanges();
            }
        }

        public void EliminaDocente(int id)
        {
            using var db = new ScuolaContext();
            var doc = db.Docenti.FirstOrDefault(d => d.Id == id);

            if (doc != null)
            {
                db.Docenti.Remove(doc);
                db.SaveChanges();
            }
        }
    }
}
