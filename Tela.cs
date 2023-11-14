using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace ProjetoXadrez
{
  class Tela
  {
    public static void imprimirPartida(PartidaDeXadrez partida)
    {
      Tela.imprimirTabuleiro(partida.tab);
      Console.WriteLine();
      imprimirPecasCapturadas(partida);
      Console.WriteLine();
      Console.WriteLine("Turno: " + partida.turno);
      Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
      if (partida.xeque)
      {
        Console.WriteLine("XEQUE!");
      }
    }
    public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
    {
      Console.WriteLine("Peças capturadas: ");
      Console.Write("Brancas: ");
      imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
      Console.WriteLine();
      Console.Write("Pretas: ");
      ConsoleColor aux = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.DarkBlue;
      imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
      Console.ForegroundColor = aux;
      Console.WriteLine();
    }
    public static void imprimirConjunto(HashSet<Peca> conjunto)
    {
      Console.Write("[");
      foreach (Peca p in conjunto)
      { 
        Console.Write(p + " "); 
      }
      Console.Write("]");
    }
    public static void imprimirTabuleiro(Tabuleiro tab)
    {
      ConsoleColor rlt = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine("  A B C D E F G H");
      Console.ForegroundColor = rlt;
      for (int i = 0; i < tab.linhas; i++)
      {
        ConsoleColor rcl = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write(8 - i + " ");
        Console.ForegroundColor = rcl;
        for (int j = 0; j < tab.colunas; j++)
        {
          imprimirPeca(tab.peca(i, j));
          if (j == 7)
          {
            ConsoleColor rcd = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(8 - i);
            Console.ForegroundColor = rcd;
          }
        }
        Console.WriteLine();
      }
      ConsoleColor rlb = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine("  A B C D E F G H");
      Console.ForegroundColor = rlb;
    }
    public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
    {
      ConsoleColor fundoOriginal = Console.BackgroundColor;
      ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

      ConsoleColor rlt = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine("  A B C D E F G H");
      Console.ForegroundColor = rlt;
      for (int i = 0; i < tab.linhas; i++)
      {
        ConsoleColor rcl = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write(8 - i + " ");
        Console.ForegroundColor = rcl;
        for (int j = 0; j < tab.colunas; j++)
        {
          if (posicoesPossiveis[i, j])
          {
            Console.BackgroundColor = fundoAlterado;
          }
          else
          {
            Console.BackgroundColor = fundoOriginal;
          }
          imprimirPeca(tab.peca(i, j));
          Console.BackgroundColor = fundoOriginal;
           if (j == 7)
           {
             ConsoleColor rcd = Console.ForegroundColor;
             Console.ForegroundColor = ConsoleColor.DarkYellow;
             Console.Write(8 - i);
             Console.ForegroundColor = rcd;
           }
        }
        Console.WriteLine();
      }
      ConsoleColor rlb = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine("  A B C D E F G H");
      Console.ForegroundColor = rlb;
      Console.BackgroundColor = fundoOriginal;
    }
    public static PosicaoXadrez lerPosicaoXadrez()
    {
      string s = Console.ReadLine().ToLower();
      char coluna = s[0];
      int linha = int.Parse(s[1] + "");
      return new PosicaoXadrez(coluna, linha);
    }
    public static void imprimirPeca(Peca peca)
    {
      if (peca == null)
      {
        ConsoleColor vazio = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("- ");
        Console.ForegroundColor = vazio;
      }
      else
      {
        if (peca.cor == Cor.Branca)
        {
          Console.Write(peca);
        }
        else
        {
          ConsoleColor aux = Console.ForegroundColor;
          Console.ForegroundColor = ConsoleColor.DarkBlue;
          Console.Write(peca);
          Console.ForegroundColor = aux;
        }
        Console.Write(" ");
      }
    }
  }
}
