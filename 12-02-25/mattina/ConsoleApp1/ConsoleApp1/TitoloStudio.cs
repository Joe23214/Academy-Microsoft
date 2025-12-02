using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class TitoloStudio
    {
        public int Id { get; set; }
        public string ? Titolo { get; set; }

        public override string ToString()
        {
            return Id + "" + Titolo;
        }

    }
}
