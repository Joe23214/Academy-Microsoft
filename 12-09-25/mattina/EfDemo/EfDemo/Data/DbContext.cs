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
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost;Database=ScuolaDB;Trusted_Connection = True; TrustServerCertificate = True; ");
        }
    }
}
