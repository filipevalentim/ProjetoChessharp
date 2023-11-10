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
        Tabuleiro tab = new Tabuleiro(8, 8);

        tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
        tab.colocarPeca(new Cavalo(tab, Cor.Preta), new Posicao(0, 1));
        tab.colocarPeca(new Bispo(tab, Cor.Preta), new Posicao(0, 2));
        tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 3));
        tab.colocarPeca(new Dama(tab, Cor.Preta), new Posicao(0, 4));
        tab.colocarPeca(new Bispo(tab, Cor.Preta), new Posicao(0, 5));
        tab.colocarPeca(new Cavalo(tab, Cor.Preta), new Posicao(0, 6));
        tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 7));

        for (int i = 0; i < tab.linhas; i++)
        {
          tab.colocarPeca(new Peao(tab, Cor.Preta), new Posicao(1, i));
          tab.colocarPeca(new Peao(tab, Cor.Branca), new Posicao(6, i));
        }

        tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(7, 0));
        tab.colocarPeca(new Cavalo(tab, Cor.Branca), new Posicao(7, 1));
        tab.colocarPeca(new Bispo(tab, Cor.Branca), new Posicao(7, 2));
        tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(7, 3));
        tab.colocarPeca(new Dama(tab, Cor.Branca), new Posicao(7, 4));
        tab.colocarPeca(new Bispo(tab, Cor.Branca), new Posicao(7, 5));
        tab.colocarPeca(new Cavalo(tab, Cor.Branca), new Posicao(7, 6));
        tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(7, 7));

        Tela.imprimirTabuleiro(tab);
      }
      catch (TabuleiroException e)
      {
        Console.WriteLine(e.Message);
      }

      PosicaoXadrez pos = new PosicaoXadrez('e', 6);
      Console.WriteLine(pos.toPosicao());
    }
  }
}