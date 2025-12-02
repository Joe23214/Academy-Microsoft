using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface iCrud
    {
        public void CreaContatto(Contatto c);
        public void EliminaContatto(Contatto c);
        public void ModificaContatto(int id);
    }
}
