using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class UniversitàController
    {
        private InterfacciaRepository repo;

        public UniversitàController(InterfacciaRepository repository)
        {
            repo = repository;
        }

        public bool AggiungiStudente(string nome, string cognome, string matricola, string codiceCorso)
            => repo.AggiungiStudente(nome, cognome, matricola, codiceCorso);

        public Studente CercaStudente(string matricola)
            => repo.CercaStudente(matricola);

        public bool AggiungiVoto(string matricola, string materia, int voto)
            => repo.AggiungiVoto(matricola, materia, voto);

        public Dictionary<string, int[]> GetVotiStudente(string matricola)
            => repo.GetVotiStudente(matricola);

        public IEnumerable<Studente> GetAllStudenti()
            => repo.GetAllStudenti();

        public Studente StudenteMediaPiuAlta()
            => repo.StudenteMediaPiuAlta();

        public bool AggiungiProfessore(string nome, string cognome, string id, string materia)
            => repo.AggiungiProfessore(nome, cognome, id, materia);

        public Professore CercaProfessore(string id)
            => repo.CercaProfessore(id);

        public bool AggiungiCorso(string codice, string nome)
            => repo.AggiungiCorso(codice, nome);

        public CorsoDiLaurea CercaCorso(string codice)
            => repo.CercaCorso(codice);

        public bool AssegnaProfessoreACorso(string idProf, string codiceCorso)
            => repo.AssegnaProfessoreACorso(idProf, codiceCorso);

        public IEnumerable<CorsoDiLaurea> GetAllCorsi()
            => repo.GetAllCorsi();

        public string StampaLibretto(string matricola)
            => repo.StampaLibretto(matricola);

        public bool AggiungiMateriaACorso(string codiceCorso, string materia)
        => repo.AggiungiMateriaACorso(codiceCorso, materia);
    }

}
