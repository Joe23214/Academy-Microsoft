using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ScuolaContext : DbContext
    {
        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Corso> Corsi { get; set; }

        public DbSet<Docente> Docenti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Studente>().HasIndex(s => s.Matricola).IsUnique();
            modelBuilder.Entity<Studente>().HasMany(s => s.Corsi).WithMany(c => c.studenti);
            modelBuilder.Entity<Corso>().HasMany(c => c.Docenti).WithMany(d => d.corsi);



        }
        public ScuolaContext(DbContextOptions<ScuolaContext> options) : base(options)
        {
        }

    }
}
