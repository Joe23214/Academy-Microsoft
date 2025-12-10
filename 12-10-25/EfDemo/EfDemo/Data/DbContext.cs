using EfDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDemo.Data
{
    public class ScuolaContext : DbContext
    {
        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Docente> Docenti { get; set; }
        public DbSet<Corso> Corsi { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost;Database=ScuolaDB;Trusted_Connection = True; TrustServerCertificate = True; ");
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
