using tabuleiro;
using xadrez;

namespace ProjetoXadrez
{
  class Program
  {
    static void Main(string[] args)
    {
      PartidaDeXadrez partida = new PartidaDeXadrez();

      while (!partida.terminada)
      {
        try
        {
          Console.Clear();
          Tela.imprimirPartida(partida);

          Console.WriteLine();
          Console.Write("Origem: ");
          Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
          partida.validarPosicaoDeOrigem(origem);

          bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();
          Console.Clear();
          Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);
          Console.WriteLine();
          Console.WriteLine("Turno: " + partida.turno);
          Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);

          Console.WriteLine();
          Console.Write("Destino: ");
          Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
          
          partida.validarPosicaoDeDestino(origem, destino);

          partida.realizarJogada(origem, destino);
        }
        catch (TabuleiroException e)
        {
          Console.WriteLine(e.Message);
          Console.ReadLine();
        }
        catch (FormatException e)
        {
          Console.WriteLine("FORMAT ERROR: " + e.Message);
          Console.ReadLine();
        }
        catch (Exception e)
        {
          Console.WriteLine("ERROR: " + e.Message);
          Console.ReadLine();
        }
      }
    }
  }
}

