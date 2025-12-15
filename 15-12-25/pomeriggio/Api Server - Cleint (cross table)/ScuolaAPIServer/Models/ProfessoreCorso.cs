namespace ScuolaAPIServer.Models
{
    public class ProfessoreCorso
    {
        public int ProfessoreId { get; set; }
        public Professore Professore { get; set; }

        public int CorsoId { get; set; }
        public Corso Corso { get; set; }
    }
}
