Agginta entità corsi, abbiamo istranziato le relazioni in questo modo:

namespace EfDemo.Models
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
_
namespace EfDemo.Models
{
    public class Docente
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List <Corso> corsi { get; set; } = new();


    }
}
_
namespace EfDemo.Models
{
    /*
     Una classe POCO (Plain Old CLass) è una classe che rappresenta un semplice
oggetto di dominio. La sua semplicità la rende facilmente utilizzabile per
serializzazione, deserializzazione e per passare dati tra diversi strati di
un'applicazione.
     */
    public class Studente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Eta { get; set; }

        public string Matricola { get; set; }
        public List<Corso> Corsi  { get; set; } = new();

    }

}
db context:

namespace EfDemo.Data
{
    public class ScuolaContext : DbContext
    {
        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Docente> Docenti { get; set; }
        public DbSet<Corso> Corsi { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost;Database=ScuolaDB2;Trusted_Connection = True; TrustServerCertificate = True; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //metodo che viene eseguito quando il modello viene creato
            //istanza che rappresenta una sessione con il db e configura in autonomia le relaizoni tra entità(?)
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Studente>().HasIndex(s => s.Matricola).IsUnique();
            //modelBuilder -> classe che modella entità in db
            //settiamo relazione molti a molti tra studente e corso
            modelBuilder.Entity<Studente>().HasMany(s => s.Corsi).WithMany(c => c.studenti);
            modelBuilder.Entity<Corso>().HasMany(c => c.Docenti).WithMany(d => d.corsi);



        }
    }
}
_
così il db context setta autonomamente le relazioni molti a molti tra studente e corso e tra corso e docente. così possiamo richiamare la lista nelle entità tracciate


TODO:
Aggiungere repository da app prof.