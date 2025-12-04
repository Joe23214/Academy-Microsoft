using System;
using ConsoleApp2.Model;
using ConsoleApp2.Repository;
using ConsoleApp2.View;
using Microsoft.Data.SqlClient;

namespace ConsoleApp2.Controller
{
    internal class Program
    {

        static void Main(string[] args)
        {
           /*

            to do:
            1 implementare connessione singleton -ok
            2 mvc pattern corretto -ok
            3 implementare crud totale di prodotti -ok
            4 implementare entità categorieProdotti + crud totale + vincoli db -ok
            5 -opt stringa di connessione fuori da progetto o fuori da classe(?) -ok

            ho messo il file txt nella root di progetto e tramite le proprietà gli ho dato contenuto e copiasempre ai primi due valori
            altrimenti non avrebbe funzioanto in debug o altri output
            */
            bool running = true;
            MainView mw = new MainView();
            Pcrud pcrud = new Pcrud();
            CCrud cCrud = new CCrud();
            while (running)
            {
                mw.visualizzaMenù();
                int scelta = mw.LeggiIntero("inserisci la scelta:");
                string msg;

                switch (scelta)
                {
                    case 1:
                        //create prodotto
                        List<Categoria> cats = cCrud.viewAll();
                        mw.ViewAllc(cats);
                        Prodotto newp = new Prodotto(); //passo prodotto vuoto a vista
                        newp = mw.CreateProdotto(newp); //vista accetta prodotto e lo restituisce valorizzato
                         msg = pcrud.createProdotto(newp); //createProdotto restituisce il messaggio di avvenuta creazione o meno
                        mw.LeggiStringa(msg); //leggo messaggio
                        break;
                    case 2:
                        //read prodotti
                        List<Prodotto> list = pcrud.viewAll();
                        mw.ViewAll(list);
                        break;
                    case 3:
                        //ricerca per Id prodotto
                        List<Prodotto> list1 = pcrud.viewAll();
                        mw.ViewAll(list1);
                        mw.selezionaId(pcrud);
                        break;
                    case 4:
                        //update prodotto
                        List<Prodotto> list2 = pcrud.viewAll();
                        mw.ViewAll(list2);
                        Prodotto pr = mw.selezionaId(pcrud);
                        List<Categoria> catss = cCrud.viewAll();
                        mw.ViewAllc(catss);
                        Prodotto prm = mw.modificaProdotto(pr);
                        msg = pcrud.updateProdotto(prm);
                        mw.LeggiStringa(msg);
                        break;
                    case 5:
                        //delete prodotto
                        List<Prodotto> list3 = pcrud.viewAll();
                        mw.ViewAll(list3);
                        Prodotto p = mw.selezionaId(pcrud);
                        msg = pcrud.deleteProdotto(p);
                        mw.LeggiStringa(msg);
                        break;
                    case 6:
                        //create categoria
                        Categoria categoria = new Categoria();
                        categoria = mw.CreateCategoria(categoria);
                        msg = cCrud.createCategoria(categoria);
                        mw.LeggiStringa(msg);
                        break;
                    case 7:
                        //mostra tutte le categorie
                        List<Categoria> listc = cCrud.viewAll();
                        mw.ViewAllc(listc);
                        break;
                    case 8:
                        //ricerca una categoria per Id
                        List<Categoria> listca = cCrud.viewAll();
                        mw.ViewAllc(listca);
                        mw.selezionaIdc(cCrud);
                        break;
                    case 9:
                        //modifica una categoria
                        List<Categoria> listcat = cCrud.viewAll();
                        mw.ViewAllc(listcat);
                        Categoria c = mw.selezionaIdc(cCrud);
                        Categoria cx = mw.modificaCategoria(c);
                        msg = cCrud.updateCategoria(cx);
                        mw.LeggiStringa(msg);
                        break;
                    case 10:
                        //elimina una categoria
                        List<Categoria> list4 = cCrud.viewAll();
                        mw.ViewAllc(list4);
                        Categoria cate = mw.selezionaIdc(cCrud);
                        msg = cCrud.deleteCategoria(cate);
                        mw.LeggiStringa(msg);
                        break;


                    default:
                        mw.LeggiStringa("Scelta non valida..");
                        break;
                }
            }
        }
    }
}