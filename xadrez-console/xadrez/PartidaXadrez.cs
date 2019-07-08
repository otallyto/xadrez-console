using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno {get; private set;}
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
            


        public PartidaXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if(x.Cor == cor)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(pecasCapturadas(cor));

            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('c',2,new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2,new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 2,new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1,new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1,new Rei(Tab, Cor.Branca));

            ColocarNovaPeca('c', 7,new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8,new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 7,new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7,new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8,new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8,new Rei(Tab, Cor.Preta));
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            //Tab.RetirarPeca(destino);
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
        }

        public void realizaJogada(Posicao origem , Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            mudaJogador();
        }

        private void mudaJogador()
        {
            if(JogadorAtual== Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public void validarPosicaoOrigem(Posicao pos)
        {
            if(Tab.Peca(pos) == null)
            {
                throw new TabuleiroExcption("Não existe peça na posição escolhida!");
            }
            if (JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroExcption("A peça de origem escolhida não é sua!");
            }
            if (!Tab.Peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroExcption("Não há movimentos para peça escolhida");
            }
        }

        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroExcption("Posição de destino invalida!");
            }
        }
    }
}
