using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Repository : InterfacciaRepository
    {
        private Dictionary<string, Studente> Studenti { get; set; }
        private Dictionary<string, Professore> Professori { get; set; }
        private Dictionary<string, CorsoDiLaurea> Corsi { get; set; }
        private Dictionary<string, Dictionary<string, List<Voto>>> votiPerStudente;

        public Repository()
        {
            Studenti = new Dictionary<string, Studente>();
            Professori = new Dictionary<string, Professore>();
            Corsi = new Dictionary<string, CorsoDiLaurea>();
            votiPerStudente = new Dictionary<string, Dictionary<string, List<Voto>>>();
        }

        public bool AggiungiStudente(string nome, string cognome, string matricola, string codiceCorso)
        {
            if (Studenti.ContainsKey(matricola) || !Corsi.ContainsKey(codiceCorso))
                return false;

            var studente = new Studente(nome, cognome, matricola)
            {
                CorsoIscritto = Corsi[codiceCorso]
            };

            Studenti.Add(matricola, studente);
            votiPerStudente[matricola] = new Dictionary<string, List<Voto>>();
            return true;
        }

        public bool ApprovaStudenteSuccessivo(CodaIscrizioni coda)
        {
            var studente = coda.ApprovaProssima();
            if (studente == null || Studenti.ContainsKey(studente.Matricola))
                return false;

            Studenti.Add(studente.Matricola, studente);
            votiPerStudente[studente.Matricola] = new Dictionary<string, List<Voto>>();
            return true;
        }

        public Studente CercaStudente(string matricola)
        {
            Studenti.TryGetValue(matricola, out var s);
            return s;
        }

        public bool AggiungiVoto(string matricola, string materia, int valore)
        {
            if (!Studenti.ContainsKey(matricola))
                return false;

            var corso = Studenti[matricola].CorsoIscritto;
            if (corso == null || !corso.Materie.Contains(materia))
                return false;

            if (!votiPerStudente[matricola].ContainsKey(materia))
                votiPerStudente[matricola][materia] = new List<Voto>();

            votiPerStudente[matricola][materia].Add(new Voto(materia, valore));
            return true;
        }

        public Dictionary<string, int[]> GetVotiStudente(string matricola)
        {
            var result = new Dictionary<string, int[]>();
            if (!votiPerStudente.ContainsKey(matricola))
                return result;

            foreach (var kvp in votiPerStudente[matricola])
            {
                int[] valori = new int[kvp.Value.Count];
                for (int i = 0; i < kvp.Value.Count; i++)
                    valori[i] = kvp.Value[i].Valore;
                result[kvp.Key] = valori;
            }

            return result;
        }

        public IEnumerable<Studente> GetAllStudenti()
        {
            return Studenti.Values;
        }

        public Studente StudenteMediaPiuAlta()
        {
            Studente migliore = null;
            double mediaMigliore = 0;

            foreach (var studente in Studenti.Values)
            {
                if (!votiPerStudente.ContainsKey(studente.Matricola))
                    continue;

                var allVotes = new List<int>();
                foreach (var votiMateria in votiPerStudente[studente.Matricola].Values)
                    foreach (var v in votiMateria)
                        allVotes.Add(v.Valore);

                double media = 0;
                if (allVotes.Count > 0)
                {
                    int somma = 0;
                    foreach (var voto in allVotes)
                        somma += voto;
                    media = (double)somma / allVotes.Count;
                }

                if (migliore == null || media > mediaMigliore)
                {
                    migliore = studente;
                    mediaMigliore = media;
                }
            }

            return migliore;
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
                : new Dictionary<string, List<Voto>>();

            var sb = new StringBuilder();
            sb.AppendLine($"Libretto di {studente.Nome} {studente.Cognome}:");

            if (voti.Count == 0)
            {
                sb.AppendLine("Nessun voto.");
            }
            else
            {
                int somma = 0;
                int count = 0;

                foreach (var materia in voti.Keys)
                {
                    sb.AppendLine($"{materia}: {string.Join(", ", voti[materia])}");
                    foreach (var v in voti[materia])
                    {
                        somma += v.Valore;
                        count++;
                    }
                }

                double media = count > 0 ? (double)somma / count : 0;
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

        public List<Studente> OrdinaStudentiPerMedia()
        {
            var lista = new List<Studente>(GetAllStudenti());

            foreach (var stud in lista)
                stud.MediaCalcolata = CalcolaMediaStudente(stud.Matricola);

            lista.Sort();
            return lista;
        }

        public double CalcolaMediaStudente(string matricola)
        {
            if (!votiPerStudente.ContainsKey(matricola))
                return 0;

            int somma = 0, count = 0;

            foreach (var lista in votiPerStudente[matricola].Values)
                foreach (var v in lista)
                {
                    somma += v.Valore;
                    count++;
                }

            return count == 0 ? 0 : (double)somma / count;
        }
    }
}
