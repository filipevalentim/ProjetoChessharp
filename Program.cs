using tabuleiro;
using xadrez;

namespace ProjetoXadrez
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        PartidaDeXadrez partida = new PartidaDeXadrez();

        Tela.imprimirTabuleiro(partida.tab);
      }
      catch (TabuleiroException e)
      {
        Console.WriteLine(e.Message);
      }
      catch (Exception e)
      {
        Console.WriteLine("ERROR: " + e.Message);
      }
    }
  }
}