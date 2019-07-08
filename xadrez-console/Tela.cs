using tabuleiro;
using System;
using xadrez;
using System.Collections.Generic;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirPartida(PartidaXadrez partida)
        {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
        }

        public static void imprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
        }

        public static void imprimirConjunto (HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {



            for (int i = 0; i < tab.Linhas; i++)
            {

                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.Colunas; j++)
                {

                    ImprimirPeca(tab.Peca(i, j));

                }

                Console.WriteLine();

            }

            Console.WriteLine("  a b c d e f g h");

        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoePossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;

            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoePossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }

                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }

                    ImprimirPeca(tab.Peca(i, j));

                    Console.BackgroundColor = fundoOriginal;
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");

            Console.BackgroundColor = fundoOriginal;
        }



        public static void ImprimirPeca(Peca peca)
        {



            if (peca == null)
            {

                Console.Write("- ");

            }

            else
            {

                if (peca.Cor == Cor.Branca)
                {

                    Console.Write(peca);

                }

                else
                {

                    ConsoleColor aux = Console.ForegroundColor;

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Write(peca);

                    Console.ForegroundColor = aux;

                }

                Console.Write(" ");

            }

        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {

            string s = Console.ReadLine();

            char coluna = s[0];

            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);

        }

    }
}
