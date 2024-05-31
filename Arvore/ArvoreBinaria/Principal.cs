using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria
{
    public class Program
    {
        static void Main()
        {
            Arvore arvore = new Arvore(42);
           
            arvore.addItem(16);
            arvore.addItem(57);
            arvore.addItem(48);
            arvore.addItem(8);
            arvore.addItem(35);
            arvore.addItem(5);
            arvore.addItem(11);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Pre ordem: " + arvore.preOrdem());
            Console.WriteLine("Em ordem: " + arvore.emOrdem());
            Console.WriteLine("Pos ordem: " + arvore.posOrdem());
        }
    }
}
