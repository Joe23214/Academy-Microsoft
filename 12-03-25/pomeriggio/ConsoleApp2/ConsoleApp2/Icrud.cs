using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    interface iCrud
    {
        string createProdotto(Prodotto p);
        string updateProdotto(Prodotto pr);
        string deleteProdotto(Prodotto p);
        List<Prodotto> viewAll();

    }

}
