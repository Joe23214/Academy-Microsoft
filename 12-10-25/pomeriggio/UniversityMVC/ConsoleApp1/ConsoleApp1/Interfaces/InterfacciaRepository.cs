using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface InterfacciaRepository
    {
        bool AggiungiStudente(string nome, string cognome, string matricola, string codiceCorso);
        Studente CercaStudente(string matricola);

        bool AggiungiVoto(string matricola, string materia, int voto);
        Dictionary<string, int[]> GetVotiStudente(string matricola);
        IEnumerable<Studente> GetAllStudenti();
        Studente StudenteMediaPiuAlta();
        string StampaLibretto(string matricola);

        bool AggiungiProfessore(string nome, string cognome, string id, string materia);
        Professore CercaProfessore(string id);

        bool AggiungiCorso(string codice, string nome);
        CorsoDiLaurea CercaCorso(string codice);

        bool AssegnaProfessoreACorso(string idProf, string codiceCorso);
        IEnumerable<CorsoDiLaurea> GetAllCorsi();
        bool AggiungiMateriaACorso(string codiceCorso, string materia);

        List<Studente> OrdinaStudentiPerMedia();
        double CalcolaMediaStudente(string matricola);

    }

}