using System.Collections.Generic;

namespace ScuolaAPIServer.Models
{
    public class Professore
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Cognome { get; set; } = "";

        public List<ProfessoreCorso> ProfessoreCorsi { get; set; } = new();

        public override string ToString()
        {
            return $"{Id}{Nome} {Cognome}";
        }
    }
}
