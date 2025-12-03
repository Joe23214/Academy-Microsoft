using System;
using System.Collections.Generic;
using System.Text;

/*
 CREATE TABLE CATEGORIE (
ID INT PRIMARY KEY IDENTITY(1,1),
CATEGORIA NVARCHAR(50),

);
 */


namespace ConsoleApp2
{
    public class Categoria
    {
        public string Id { get; set; }
        public string TipoCategoria { get; set; }

        public Categoria() { }

        public override string ToString()
        {
            return $"Questa è la categoria con id {Id} di Categoria: {TipoCategoria}.";
        }


    }
}
