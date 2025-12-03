using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface iCrud
    {
        void CreaContatto(Contatto c);
        void EliminaContatto(int id);
        void ModificaContatto(Contatto c);
    }

   
}
