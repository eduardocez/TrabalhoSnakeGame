using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoCObra
{
    internal class Cobra
    {
        private int[] cobraLinhas;
        private int[] cobraColunas;
        private int tamanhoCobra;

        private int linha;
        private int coluna;
        private int direcaoAtual;

        private readonly int CIMA = 0;
        private readonly int BAIXO = 1;
        private readonly int ESQUERDA = 2;
        private readonly int DIREITA = 3;

        public int[] CobraLinhas
        {
            get { return cobraLinhas; }
            set { cobraLinhas = value; }
        }

        public int[] CobraColunas
        {
            get { return cobraColunas; }
            set { cobraColunas = value; }
        }

        public int TamanhoCobra
        {
            get { return tamanhoCobra; }
            set { tamanhoCobra = value; }
        }

        public int Linha
        {
            get { return linha; }
            set { linha = value; }
        }

        public int Coluna
        {
            get { return coluna; }
            set { coluna = value; }
        }

        public int DirecaoAtual
        {
            get { return direcaoAtual; }
            set { direcaoAtual = value; }
        }

        public Cobra(int linhaInicial, int colunaInicial)
        {
            cobraLinhas = new int[600];
            cobraColunas = new int[600];

            tamanhoCobra = 3;
            direcaoAtual = DIREITA;

            this.linha = linhaInicial;
            this.coluna = colunaInicial;

            cobraLinhas[0] = linhaInicial;
            cobraColunas[0] = colunaInicial;

            cobraLinhas[1] = linhaInicial;
            cobraColunas[1] = colunaInicial - 1;

            cobraLinhas[2] = linhaInicial;
            cobraColunas[2] = colunaInicial - 2;
        }

        public void MoverCabeca()
        {
            if (direcaoAtual == CIMA)
            {
                linha -= 1;
            }
            else if (direcaoAtual == BAIXO)
            {
                linha += 1;
            }
            else if (direcaoAtual == ESQUERDA)
            {
                coluna -= 1;
            }
            else if (direcaoAtual == DIREITA)
            {
                coluna += 1;
            }
        }

        public void AtualizarCorpo()
        {
            for (int i = tamanhoCobra - 1; i > 0; i--)
            {
                cobraLinhas[i] = cobraLinhas[i - 1];
                cobraColunas[i] = cobraColunas[i - 1];
            }

            cobraLinhas[0] = linha;
            cobraColunas[0] = coluna;
        }

        public void Crescer()
        {
            cobraLinhas[tamanhoCobra] = cobraLinhas[tamanhoCobra - 1];
            cobraColunas[tamanhoCobra] = cobraColunas[tamanhoCobra - 1];
            tamanhoCobra++;
        }
    }
}
