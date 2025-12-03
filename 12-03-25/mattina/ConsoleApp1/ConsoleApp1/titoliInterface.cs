using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface iCrudTitoli
    {
        void CreaTitolo(TitoloStudio t);
        void ModificaTitolo(TitoloStudio t);
        void EliminaTitolo(int id);
        List<TitoloStudio> FindAll();
        TitoloStudio? GetById(int id);
    }
}