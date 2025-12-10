using EfDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EfDemo.Repositories
{
    public interface IStudenteRepository
    {
        IQueryable<Studente> GetAll();
        Studente? GetById(int id);
        void Add(Studente studente);
        void Update(Studente studente);
        void Delete(Studente studente);

        void AssegnaCorso(Studente studente, Corso corso);
        void RimuoviCorso(Studente studente, Corso corso);

        void Save();
    }
}
