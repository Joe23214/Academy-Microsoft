using System.Collections.Generic;

namespace ScuolaAPIServer.Models
{
    public class Corso
    {
        public int Id { get; set; }
        public string Codice { get; set; } = "";
        public string Nome { get; set; } = "";

        public List<StudenteCorso> StudenteCorsi { get; set; } = new();
        public List<ProfessoreCorso> ProfessoreCorsi { get; set; } = new();

        public override string ToString()
        {
            return $"Id: {Id}, Codice corso: {Codice} - {Nome} ";
        }
    }
}
