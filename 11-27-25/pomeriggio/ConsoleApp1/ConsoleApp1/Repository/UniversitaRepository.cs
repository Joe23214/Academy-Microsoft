using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Repository : InterfacciaRepository
    {
        private Dictionary<string, Studente> Studenti { get; set; }
        private Dictionary<string, Professore> Professori { get; set; }
        private Dictionary<string, CorsoDiLaurea> Corsi { get; set; }
        private Dictionary<string, Dictionary<string, List<int>>> votiPerStudente;

        public Repository()
        {
            Studenti = new Dictionary<string, Studente>();
            Professori = new Dictionary<string, Professore>();
            Corsi = new Dictionary<string, CorsoDiLaurea>();
            votiPerStudente = new Dictionary<string, Dictionary<string, List<int>>>();
        }

        public bool AggiungiStudente(string nome, string cognome, string matricola, string codiceCorso)
        {
            if (Studenti.ContainsKey(matricola) || !Corsi.ContainsKey(codiceCorso))
                return false;

            var studente = new Studente(nome, cognome, matricola);
            studente.CorsoIscritto = Corsi[codiceCorso];
            Studenti.Add(matricola, studente);
            votiPerStudente[matricola] = new Dictionary<string, List<int>>();
            return true;
        }

        public Studente CercaStudente(string matricola)
        {
            Studenti.TryGetValue(matricola, out var s);
            return s;
        }

        public bool AggiungiVoto(string matricola, string materia, int voto)
        {
            if (!Studenti.ContainsKey(matricola))
                return false;

            if (!votiPerStudente[matricola].ContainsKey(materia))
                votiPerStudente[matricola][materia] = new List<int>();

            votiPerStudente[matricola][materia].Add(voto);
            return true;
        }

        public Dictionary<string, int[]> GetVotiStudente(string matricola)
        {
            if (!votiPerStudente.ContainsKey(matricola))
                return new Dictionary<string, int[]>();

            return votiPerStudente[matricola].ToDictionary(k => k.Key, k => k.Value.ToArray());
        }

        public IEnumerable<Studente> GetAllStudenti()
        {
            return Studenti.Values;
        }

        public Studente StudenteMediaPiuAlta()
        {
            return Studenti.Values
                .OrderByDescending(s =>
                {
                    if (!votiPerStudente.ContainsKey(s.Matricola)) return 0;
                    var allVotes = votiPerStudente[s.Matricola].Values.SelectMany(v => v);
                    return allVotes.Any() ? allVotes.Average() : 0;
                })
                .FirstOrDefault();
        }

        public bool AggiungiProfessore(string nome, string cognome, string id, string materia)
        {
            if (Professori.ContainsKey(id))
                return false;

            Professori.Add(id, new Professore(nome, cognome, id, materia));
            return true;
        }

        public Professore CercaProfessore(string id)
        {
            Professori.TryGetValue(id, out var p);
            return p;
        }

        public bool AggiungiCorso(string codice, string nome)
        {
            if (Corsi.ContainsKey(codice))
                return false;

            Corsi.Add(codice, new CorsoDiLaurea(codice, nome));
            return true;
        }

        public CorsoDiLaurea CercaCorso(string codice)
        {
            Corsi.TryGetValue(codice, out var c);
            return c;
        }

        public bool AssegnaProfessoreACorso(string idProf, string codiceCorso)
        {
            if (!Professori.ContainsKey(idProf) || !Corsi.ContainsKey(codiceCorso))
                return false;

            var prof = Professori[idProf];
            var corso = Corsi[codiceCorso];

            if (!corso.Professori.Contains(prof))
                corso.Professori.Add(prof);

            if (!prof.Corsi.Contains(corso))
                prof.Corsi.Add(corso);

            return true;
        }

        public IEnumerable<CorsoDiLaurea> GetAllCorsi()
        {
            return Corsi.Values;
        }

        public string StampaLibretto(string matricola)
        {
            if (!Studenti.ContainsKey(matricola))
                return "Studente non trovato.";

            var studente = Studenti[matricola];
            var voti = votiPerStudente.ContainsKey(matricola)
                ? votiPerStudente[matricola]
                : new Dictionary<string, List<int>>();

            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"Libretto di {studente.Nome} {studente.Cognome}:");

            if (!voti.Any())
            {
                sb.AppendLine("Nessun voto.");
            }
            else
            {
                foreach (var materia in voti.Keys)
                {
                    sb.AppendLine($"{materia}: {string.Join(", ", voti[materia])}");
                }

                double media = voti.Values.SelectMany(v => v).DefaultIfEmpty(0).Average();
                sb.AppendLine($"Media: {media:F2}");
            }

            return sb.ToString();
        }

        public bool AggiungiMateriaACorso(string codiceCorso, string materia)
        {
            if (!Corsi.ContainsKey(codiceCorso))
                return false;

            var corso = Corsi[codiceCorso];

            if (!corso.Materie.Contains(materia))
                corso.Materie.Add(materia);

            return true;
        }


    }

}
