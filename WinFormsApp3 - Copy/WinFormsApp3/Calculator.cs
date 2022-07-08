using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp3
{
    class Calculator
    {
       
        public void Quick_maffs(string k, List<string> lista)
        {
            long temp = 0;
           
            // beroende på matematisk operation
                          // hitta talet till vänster om operationen                och till höger
            if (k == "*") { temp = Int64.Parse(lista[lista.IndexOf(k) - 1]) * Int64.Parse(lista[lista.IndexOf(k) + 1]); }
            else if (k == "/") { temp = Int64.Parse(lista[lista.IndexOf(k) - 1]) / Int64.Parse(lista[lista.IndexOf(k) + 1]); }

            else if (k == "+") { temp = Int64.Parse(lista[lista.IndexOf(k) - 1]) + Int64.Parse(lista[lista.IndexOf(k) + 1]); }

            else if (k == "-") { temp = Int64.Parse(lista[lista.IndexOf(k) - 1]) - Int64.Parse(lista[lista.IndexOf(k) + 1]); }

            lista[lista.IndexOf(k) - 1] = temp.ToString(); // index där operatinen satt, blir nu resultatet
            lista.RemoveAt(lista.IndexOf(k) + 1); // ta bort före, och efter
            lista.RemoveAt(lista.IndexOf(k));
        }
    }
}
