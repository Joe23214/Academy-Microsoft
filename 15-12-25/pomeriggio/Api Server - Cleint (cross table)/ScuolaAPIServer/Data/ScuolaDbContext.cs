using Microsoft.EntityFrameworkCore;
using ScuolaAPIServer.Models;

namespace ScuolaAPIServer.Data
{
    public class ScuolaDbContext : DbContext
    {

        public ScuolaDbContext(DbContextOptions<ScuolaDbContext> options) : base(options)
        {

        }

        public DbSet<Studente> Studenti { get; set; } = null!;
        public DbSet<Corso> Corsi { get; set; } = null!;
        public DbSet<Professore> Professori { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // STUDENTE-CORSO
            modelBuilder.Entity<StudenteCorso>()
                .HasKey(sc => new { sc.StudenteId, sc.CorsoId });

            modelBuilder.Entity<StudenteCorso>()
                .HasOne(sc => sc.Studente)
                .WithMany(s => s.StudenteCorsi)
                .HasForeignKey(sc => sc.StudenteId);

            modelBuilder.Entity<StudenteCorso>()
                .HasOne(sc => sc.Corso)
                .WithMany(c => c.StudenteCorsi)
                .HasForeignKey(sc => sc.CorsoId);

            // PROFESSORE-CORSO
            modelBuilder.Entity<ProfessoreCorso>()
                .HasKey(pc => new { pc.ProfessoreId, pc.CorsoId });

            modelBuilder.Entity<ProfessoreCorso>()
                .HasOne(pc => pc.Professore)
                .WithMany(p => p.ProfessoreCorsi)
                .HasForeignKey(pc => pc.ProfessoreId);

            modelBuilder.Entity<ProfessoreCorso>()
                .HasOne(pc => pc.Corso)
                .WithMany(c => c.ProfessoreCorsi)
                .HasForeignKey(pc => pc.CorsoId);
        }
    }
}
