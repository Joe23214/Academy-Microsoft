using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Studente
    {
        private string nome;
        private string cognome;
        private string matricola;

        private List<int> voti;

        public Studente(string nome, string cognome, string matricola)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.matricola = matricola;
            voti = new List<int>();
        }

        public string Nome { get => nome; }
        public string Cognome { get => cognome; }
        public string Matricola { get => matricola; }

        public double Media
        {
            get
            {
                if (voti.Count == 0) return 0;
                double somma = 0;
                foreach (int v in voti)
                    somma += v;
                return somma / voti.Count;
            }
        }

        public int NumeroVoti => voti.Count;

        public void AggiungiVoto(int voto)
        {
            voti.Add(voto);
        }

        public void RimuoviUltimoVoto()
        {
            if (voti.Count > 0)
                voti.RemoveAt(voti.Count - 1);
        }

        public void StampaLibretto()
        {
            Console.WriteLine($"Libretto {Nome} {Cognome} (Matricola: {Matricola})");
            foreach (int voto in voti)
                Console.WriteLine($"- {voto}");
            Console.WriteLine($"Media: {Media:F2}");
        }

        public override string ToString()
        {
            return $"{Nome} {Cognome} (Mat: {Matricola}) - Media: {Media:F2}, Voti: {NumeroVoti}";
        }
    }
}
