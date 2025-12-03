using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class CorsoDiLaurea
    {
        public string Codice { get; }
        public string Nome { get; }
        public List<Professore> Professori { get; }
        public List<string> Materie { get; }

        public CorsoDiLaurea(string codice, string nome)
        {
            Codice = codice;
            Nome = nome;
            Professori = new List<Professore>();
            Materie = new List<string>();
        }

        public override string ToString()
        {
            if (Professori == null || Professori.Count == 0)
                return $"{Nome} (Cod: {Codice}) - Nessun professore assegnato";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Professori.Count; i++)
            {
                var p = Professori[i];
                if (p != null)
                {
                    sb.Append(p.Nome + " " + p.Cognome + $" ({p.Materia})");
                    if (i < Professori.Count - 1) sb.Append(", ");
                }
            }

            return $"{Nome} (Cod: {Codice}) - Professori: {sb}";
        }
    }
}
