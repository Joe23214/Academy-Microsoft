namespace Client.Models
{
    public class Corso
    {
        public int Id { get; set; }
        public string codiceCorso { get; set; }
        public string Titolo { get; set; }

        public List<Docente> Docenti { get; set; } = new();
        public List<Studente> studenti { get; set; } = new();

    }
}
