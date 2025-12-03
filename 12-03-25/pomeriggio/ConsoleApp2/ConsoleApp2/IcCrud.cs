using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    interface IcCrud
    {
        string createCategoria(Categoria c);
        string updateCategoria(Categoria c);
        string deleteCategoria(Categoria c);
        List<Categoria> viewAll();
    }
}
