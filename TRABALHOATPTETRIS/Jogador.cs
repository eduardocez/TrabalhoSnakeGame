using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrabalhoCobra
{
    internal class Jogador

    { public string Nome;
        public int pontos;
        public Jogador(string nome)
        {
            this.Nome = nome;
            this.pontos = 0;
        }

        public void AtualizaPonto(int pontuacaoRecebida)
        {
            this.pontos += pontuacaoRecebida;


        }
        public void SalvarPontuacao()
        {

            StreamWriter esc = new StreamWriter("scores.txt", true, Encoding.UTF8);
            esc.WriteLine($"Jogador: {this.Nome}");
            esc.WriteLine($"Pontos: {this.pontos}");

            esc.Close();
        }
    }
}

    
    

