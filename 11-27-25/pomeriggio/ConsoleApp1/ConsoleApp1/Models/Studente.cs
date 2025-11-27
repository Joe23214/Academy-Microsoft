using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Studente
    {
        public string Nome { get; }
        public string Cognome { get; }
        public string Matricola { get; }
        public CorsoDiLaurea CorsoIscritto { get; private set; }
        private Dictionary<string, List<int>> votiPerMateria;

        public Studente(string nome, string cognome, string matricola)
        {
            Nome = nome;
            Cognome = cognome;
            Matricola = matricola;
            votiPerMateria = new Dictionary<string, List<int>>();
        }

        public void IscrivitiCorso(CorsoDiLaurea corso)
        {
            CorsoIscritto = corso;
        }

        public bool AggiungiVoto(string materia, int voto)
        {
            if (CorsoIscritto == null || !CorsoIscritto.Materie.Contains(materia))
                return false;

            if (!votiPerMateria.ContainsKey(materia))
                votiPerMateria[materia] = new List<int>();

            votiPerMateria[materia].Add(voto);
            return true;
        }

        public double Media
        {
            get
            {
                var tuttiVoti = votiPerMateria.Values.SelectMany(v => v).ToList();
                if (!tuttiVoti.Any()) return 0;
                return tuttiVoti.Average();
            }
        }

        public int NumeroVoti => votiPerMateria.Values.Sum(v => v.Count);

        public void StampaLibretto()
        {
            Console.WriteLine($"Libretto {Nome} {Cognome} (Matricola: {Matricola})");
            foreach (var kv in votiPerMateria)
            {
                Console.WriteLine($"Materia: {kv.Key}");
                foreach (int voto in kv.Value)
                    Console.WriteLine($"- {voto}");
            }
            Console.WriteLine($"Media generale: {Media:F2}");
        }

        public override string ToString()
        {
            string corso = CorsoIscritto != null ? CorsoIscritto.Nome : "Non iscritto";
            return $"{Nome} {Cognome} (Mat: {Matricola}) - Corso: {corso} - Media: {Media:F2}, Voti: {NumeroVoti}";
        }
    }
}
