using System.ComponentModel.DataAnnotations;

namespace ScuolaAPIServer.Models
{
    public class Studente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(13)]
        public string Matricola { get; set; } = "";
        [Required]
        public string Nome { get; set; } = "";
        [Required]
        public string Cognome { get; set; } = "";
        public int Età { get; set; }

        public List<StudenteCorso> StudenteCorsi { get; set; } = new();
        public override string ToString()
        {
            return $"{Id}{Matricola} - {Nome}{Cognome} (Età: {Età}) ";
        }
    }
}