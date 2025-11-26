using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria
{
    public class Mensola
    {
        private List<Libro> volumi;

       public Mensola() { 
        volumi = new List<Libro>();
        }

      
        public List<Libro> getLibri()
        {
            return volumi; 
        }

        public void ordinaPerPrezzo()
        {
            volumi.Sort((a, b) => a.Prezzo().CompareTo(b.Prezzo()));
        }


        public void pulisciMensola()
        {
            volumi.Clear();
        }
    }
}
