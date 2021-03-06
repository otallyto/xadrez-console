﻿using tabuleiro;



namespace xadrez
{

    class Rei : Peca
    {



        private PartidaXadrez Partida;



        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }



        public override string ToString()
        {

            return "R";

        }



        private bool podeMover(Posicao pos)
        {

            Peca p = Tab.Peca(pos);

            return p == null || p.Cor != Cor;

        }



        private bool testeTorreParaRoque(Posicao pos)
        {

            Peca p = Tab.Peca(pos);

            return p != null && p is Torre && p.Cor == Cor && p.QteMovimentos == 0;

        }



        public override bool[,] MovimentosPossiveis()
        {

            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];



            Posicao pos = new Posicao(0, 0);



            // acima

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);

            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {

                mat[pos.Linha, pos.Coluna] = true;

            }

            // ne

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);

            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {

                mat[pos.Linha, pos.Coluna] = true;

            }

            // direita

            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);

            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {

                mat[pos.Linha, pos.Coluna] = true;

            }

            // se

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);

            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {

                mat[pos.Linha, pos.Coluna] = true;

            }

            // abaixo

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);

            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {

                mat[pos.Linha, pos.Coluna] = true;

            }

            // so

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);

            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {

                mat[pos.Linha, pos.Coluna] = true;

            }

            // esquerda

            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);

            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {

                mat[pos.Linha, pos.Coluna] = true;

            }

            // no

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {

                mat[pos.Linha, pos.Coluna] = true;

            }
            return mat;
        }

    }
}