using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TrabalhoCObra;

namespace TrabalhoCobra
{
    internal class Tabuleiro
    {
        public int[,] tabuleiro = new int[20, 30];

        public Jogador a;

        public Cobra cobra;

        public int comidaLinha;
        public int comidaColuna;

        public int pontos = 0;
        private int linhaP = -1;
        public bool JogoAcabou = false;

        private int CIMA = 0;
        private int BAIXO = 1;
        private int ESQUERDA = 2;
        private int DIREITA = 3;


        public Tabuleiro(Jogador jogador1)
        {
            this.a = jogador1;

            int linhaInicial = 10;
            int colunaInicial = 15;
            this.cobra = new Cobra(linhaInicial, colunaInicial);

            GerarComida();
        }

        public bool VerificarColisao(int futuraLinha, int futuraColuna)
        {
            if (futuraColuna < 0 || futuraColuna >= tabuleiro.GetLength(1))
            {
                return true;
            }
            if (futuraLinha < 0 || futuraLinha >= tabuleiro.GetLength(0))
            {
                return true;
            }

            for (int i = 1; i < cobra.TamanhoCobra; i++)
            {
                if (cobra.CobraLinhas[i] == futuraLinha && cobra.CobraColunas[i] == futuraColuna)
                {
                    return true;
                }
            }

            return false;
        }

        public int[,] DesenhaTabuleiro()
        {
            Console.Clear();

            cobra.MoverCabeca();
            int novaLinha = cobra.Linha;
            int novaColuna = cobra.Coluna;

            if (VerificarColisao(novaLinha, novaColuna))
            {
                JogoAcabou = true;
                Console.ResetColor();
                a.SalvarPontuacao();
                return tabuleiro;
            }

            cobra.AtualizarCorpo();

            if (novaLinha == comidaLinha && novaColuna == comidaColuna)
            {
                a.AtualizaPonto(10);
                cobra.Crescer();
                GerarComida();
            }

            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {
                    tabuleiro[i, j] = 0;
                }
            }

            tabuleiro[comidaLinha, comidaColuna] = 1;

            for (int i = 0; i < cobra.TamanhoCobra; i++)
            {
                tabuleiro[cobra.CobraLinhas[i], cobra.CobraColunas[i]] = 2;
            }

            Console.Write("██");
            for (int j = 0; j < tabuleiro.GetLength(1) * 2; j++)
            {
                Console.Write('█');
            }
            Console.WriteLine();

            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                Console.Write("█");
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {
                    if (tabuleiro[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("■ ");
                        Console.ResetColor();
                    }
                    else if (tabuleiro[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("■ ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                    if (j == tabuleiro.GetLength(1) - 1)
                    {
                        Console.Write("█");
                    }
                }
                Console.WriteLine();
            }

  
            Console.Write("██");
            for (int j = 0; j < tabuleiro.GetLength(1) * 2; j++)
            {
                Console.Write('█');
            }
            Console.WriteLine();

            Console.Write($" NOME: {a.Nome}");
            Console.Write($" PONTUAÇÃO: {a.pontos}");

            return tabuleiro;
        }


        public void MoverCobraTeclado()
        {
            while (!JogoAcabou)
            {
                if (Console.KeyAvailable)
                {
                    System.ConsoleKey conteudoleitura = Console.ReadKey(true).Key;

                    if ((conteudoleitura == ConsoleKey.A || conteudoleitura == ConsoleKey.LeftArrow) && cobra.DirecaoAtual != DIREITA)
                    {
                        cobra.DirecaoAtual = ESQUERDA;
                    }
                    else if ((conteudoleitura == ConsoleKey.D || conteudoleitura == ConsoleKey.RightArrow) && cobra.DirecaoAtual != ESQUERDA)
                    {
                        cobra.DirecaoAtual = DIREITA;
                    }
                    else if (conteudoleitura == ConsoleKey.UpArrow && cobra.DirecaoAtual != BAIXO)
                    {
                        cobra.DirecaoAtual = CIMA;
                    }
                    else if (conteudoleitura == ConsoleKey.DownArrow && cobra.DirecaoAtual != CIMA)
                    {
                        cobra.DirecaoAtual = BAIXO;
                    }
                }

                DesenhaTabuleiro();

                Thread.Sleep(200);
            }
        }

        private void GerarComida()
        {
            Random rnd = new Random();
            int novaLinha, novaColuna;
            bool teste;

            do
            {
                novaLinha = rnd.Next(tabuleiro.GetLength(0));
                novaColuna = rnd.Next(tabuleiro.GetLength(1));

                teste = false;
                for (int i = 0; i < cobra.TamanhoCobra; i++)
                {
                    if (cobra.CobraLinhas[i] == novaLinha && cobra.CobraColunas[i] == novaColuna)
                    {
                        teste = true;
                        break;
                    }
                }
            } while (teste);

            comidaLinha = novaLinha;
            comidaColuna = novaColuna;
        }
    }
}
