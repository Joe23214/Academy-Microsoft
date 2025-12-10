using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class RepositoryGenerico<T> where T : IEntita
    {
        private Dictionary<string, T> elementi = new Dictionary<string, T>();
            //CRUD BASE
        public bool Aggiungi(T elemento)
        {
            if (elementi.ContainsKey(elemento.Id))
                return false;

            elementi[elemento.Id] = elemento;
            return true;
        }

        public T GetById(string id)
        {
            elementi.TryGetValue(id, out var elemento);
            return elemento;
        }

        public IEnumerable<T> GetAll()
        {
            return elementi.Values;
        }

        public bool Aggiorna(T elemento)
        {
            if (!elementi.ContainsKey(elemento.Id))
                return false;

            elementi[elemento.Id] = elemento;
            return true;
        }

        public bool Rimuovi(string id)
        {
            return elementi.Remove(id);
        }

        public int Count => elementi.Count;
    }
}
