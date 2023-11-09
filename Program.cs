using Tabuleiro;

namespace ProjetoXadrez
{
  class Program
  {
    static void Main(string[] args)
    {
      Posicao posicao = new Posicao(3, 4);
      Console.WriteLine("Posição: " + posicao.ToString());
    }
  }
}