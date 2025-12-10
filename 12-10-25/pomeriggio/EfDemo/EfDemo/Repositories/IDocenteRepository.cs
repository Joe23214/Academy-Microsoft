using EfDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EfDemo.Repositories
{
    public interface IDocenteRepository
    {
        IQueryable<Docente> GetAll();
        Docente? GetById(int id);
        void Add(Docente docente);
        void Update(Docente docente);
        void Delete(Docente docente);

        void AssegnaCorso(Docente docente, Corso corso);
        void RimuoviCorso(Docente docente, Corso corso);

        void Save();
    }
}
