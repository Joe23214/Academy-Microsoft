using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class UniversitàController
    {
        private Repository repository;

        public UniversitàController(Repository repo)
        {
            repository = repo;
        }

        public bool AggiungiStudente(string nome, string cognome, string matricola, string codiceCorso)
        {
            if (repository.Studenti.ContainsKey(matricola))
                return false;

            if (!repository.Corsi.TryGetValue(codiceCorso, out CorsoDiLaurea corso))
                return false;

            var studente = new Studente(nome, cognome, matricola);
            studente.IscrivitiCorso(corso);
            repository.Studenti.Add(matricola, studente);
            return true;
        }

        public Studente CercaStudente(string matricola)
        {
            repository.Studenti.TryGetValue(matricola, out Studente s);
            return s;
        }

        public bool AggiungiVoto(string matricola, string materia, int voto)
        {
            if (!repository.Studenti.TryGetValue(matricola, out Studente s))
                return false;

            return s.AggiungiVoto(materia, voto);
        }

        public IEnumerable<Studente> GetAllStudenti()
        {
            return repository.Studenti.Values;
        }

        public Studente StudenteMediaPiuAlta()
        {
            return repository.Studenti.Values.OrderByDescending(s => s.Media).FirstOrDefault();
        }

        public bool AggiungiProfessore(string nome, string cognome, string id, string materia)
        {
            if (repository.Professori.ContainsKey(id))
                return false;

            repository.Professori.Add(id, new Professore(nome, cognome, id, materia));
            return true;
        }

        public Professore CercaProfessore(string id)
        {
            repository.Professori.TryGetValue(id, out Professore p);
            return p;
        }

        public bool AggiungiCorso(string codice, string nome)
        {
            if (repository.Corsi.ContainsKey(codice))
                return false;

            repository.Corsi.Add(codice, new CorsoDiLaurea(codice, nome));
            return true;
        }

        public CorsoDiLaurea CercaCorso(string codice)
        {
            repository.Corsi.TryGetValue(codice, out CorsoDiLaurea c);
            return c;
        }

        public bool AssegnaProfessoreACorso(string idProf, string codiceCorso)
        {
            if (!repository.Professori.TryGetValue(idProf, out Professore prof))
                return false;

            if (!repository.Corsi.TryGetValue(codiceCorso, out CorsoDiLaurea corso))
                return false;

            corso.AggiungiProfessore(prof);
            return true;
        }

        public IEnumerable<CorsoDiLaurea> GetAllCorsi()
        {
            return repository.Corsi.Values;
        }
    }
}
