using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using tabuleiro;
using xadrez;

namespace ProjetoXadrez
{
  class Tela
  {
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
          if (tab.peca(i, j) == null)
          {
            ConsoleColor vazio = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("- ");
            Console.ForegroundColor = vazio;
          }
          else
          {
            imprimirPeca(tab.peca(i, j));
            Console.Write(" ");
          }
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
    public static PosicaoXadrez lerPosicaoXadrez()
    {
      string s = Console.ReadLine().ToLower();
      char coluna = s[0];
      int linha = int.Parse(s[1] + "");
      return new PosicaoXadrez(coluna, linha);
    }
    public static void imprimirPeca(Peca peca)
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
    }
  }
}
