using System;
using System.Collections.Generic;
using System.Text;

/*
 CREATE TABLE CATEGORIE (
ID INT PRIMARY KEY IDENTITY(1,1),
CATEGORIA NVARCHAR(50),

);
 */


namespace ConsoleApp2.Model
{
    public class Categoria
    {
        public int Id { get; set; }
        public string TipoCategoria { get; set; }

        public Categoria() { }

        public override string ToString()
        {
            return $"Questa è la categoria con id {Id} di Categoria: {TipoCategoria}.";
        }


    }
}
