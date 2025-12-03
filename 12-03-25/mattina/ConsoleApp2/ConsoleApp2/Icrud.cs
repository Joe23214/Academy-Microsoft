using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    interface iCrud
    {
        Prodotti createProdotto(Prodotti p);
        Prodotti updateProdotto(Prodotti p);
        Prodotti deleteProdotto(Prodotti p);
        Prodotti findByIdProdotto(int i);
        void viewAll();

    }
}
