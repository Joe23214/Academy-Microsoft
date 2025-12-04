using System;

namespace ConsoleApp1
{
    public class StoricoOperazioni
    {
        private Stack<string> operazioni = new Stack<string>();

        public int Count => operazioni.Count;

        public void Registra(string operazione)
        {
            operazioni.Push(operazione);
        }

        public string UltimaOperazione()
        {
            if (operazioni.Count == 0)
                return "Nessuna operazione presente.";
            return operazioni.Peek();
        }

        public string Annulla()
        {
            if (operazioni.Count == 0)
                return "Nessuna operazione da annullare.";
            return operazioni.Pop();
        }

        public List<string> OttieniTutte()
        {
            return new List<string>(operazioni);
        }
    }
}