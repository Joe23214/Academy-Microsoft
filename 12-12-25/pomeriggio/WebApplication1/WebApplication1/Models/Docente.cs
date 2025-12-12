namespace WebApplication1.Models
{
    public class Docente
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Corso> corsi { get; set; } = new();


    }
}
