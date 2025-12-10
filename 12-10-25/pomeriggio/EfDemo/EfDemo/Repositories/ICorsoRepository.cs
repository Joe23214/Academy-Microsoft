using EfDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EfDemo.Repositories
{
    public interface ICorsoRepository
    {
        IQueryable<Corso> GetAll();
        Corso? GetById(int id);
        void Add(Corso corso);
        void Update(Corso corso);
        void Delete(Corso corso);
        void AssegnaDocente(Corso corso, Docente docente);
        void AssegnaStudente(Corso corso, Studente studente);

        void Save();
    }
}
