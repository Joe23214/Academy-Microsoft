using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class StudentiController
    {
        public Dictionary<string, Studente> studenti;

        public StudentiController()
        {
            studenti = new Dictionary<string, Studente>();
        }

        public bool AggiungiStudente(string nome, string cognome, string matricola)
        {
            if (studenti.ContainsKey(matricola))
                return false;

            studenti.Add(matricola, new Studente(nome, cognome, matricola));
            return true;
        }

        public Studente Cerca(string matricola)
        {
            studenti.TryGetValue(matricola, out Studente trovato);
            return trovato;
        }

        public bool AggiungiVoto(string matricola, int voto)
        {
            if (studenti.TryGetValue(matricola, out Studente s))
            {
                s.AggiungiVoto(voto);
                return true;
            }
            return false;
        }

        public IEnumerable<Studente> GetAll()
        {
            foreach (var item in studenti.Values)
                yield return item;
        }

        public Studente MediaPiuAlta()
        {
            Studente best = null;

            foreach (var s in studenti.Values)
            {
                if (best == null || s.Media > best.Media)
                    best = s;
            }
            return best;
        }
    }
}
