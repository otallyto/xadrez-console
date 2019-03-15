using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                PartidaXadrez partida = new PartidaXadrez();

                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.Turno);
                        Console.WriteLine("Aguardando jogador: " + partida.JogadorAtual);


                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.validarPosicaoOrigem(origem);


                        bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.validarPosicaoDestino(origem, destino);

                        //partida.ExecutaMovimento(origem, destino);
                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroExcption e)
                    {

                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    
                }

            }
            catch (TabuleiroExcption e)
            {

                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
