namespace ScuolaAPIServer.Models
{
    public class StudenteCorso
    {
        public int StudenteId { get; set; }
        public Studente Studente { get; set; }

        public int CorsoId { get; set; }
        public Corso Corso { get; set; }
    }
}