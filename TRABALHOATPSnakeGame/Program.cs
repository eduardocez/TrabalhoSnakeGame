using System.Resources;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace TrabalhoCobra
{     
internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("digite seu nome: ");
            string nome = Console.ReadLine();

            Jogador jogador = new Jogador(nome);
            Tabuleiro jogo = new Tabuleiro(jogador);


            jogo.MoverCobraTeclado();


            Console.WriteLine($"Placar Final de {jogador.Nome}: {jogador.pontos} pontos");

            Console.ReadKey();


        }
    }
}
