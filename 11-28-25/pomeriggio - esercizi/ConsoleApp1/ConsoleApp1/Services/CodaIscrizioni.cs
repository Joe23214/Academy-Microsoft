using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class CodaIscrizioni
    {
        Queue<Studente> coda = new Queue<Studente>();

        public void AggiungiRichiesta(Studente s)
        {
            foreach (var stud in coda)
            {
                if (stud.Matricola == s.Matricola)
                    throw new InvalidOperationException("Studente già presente in coda.");
            }

            coda.Enqueue(s);
        }
        public Studente ApprovaProssima()
        {
            if (coda.Count == 0)
            {
                return null;
            }
            else
            {
                return coda.Dequeue();
            }
        }
        public Studente ProssimoInCoda() {
            if (coda.Count == 0)
            {
                return null;
            }
            else
            {
                return coda.Peek();
            }
        }
        public List<Studente> OttieniRichiesteInAttesa() {
            List<Studente> lista = new List<Studente>();
            foreach (var stud in coda)
                lista.Add(stud);

            return lista;
        }
        public int NumeroRichieste
        {
            get { return coda.Count; }
        }
    }
}