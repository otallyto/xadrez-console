using System;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Posicao p = new Posicao(1, 1);
            Console.WriteLine(p);
            Tabuleiro tab = new Tabuleiro(8, 8);

            Console.ReadLine();
        }
    }
}
