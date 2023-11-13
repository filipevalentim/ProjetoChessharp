using tabuleiro;

namespace xadrez
{
  class Peao : Peca
  {
    public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) { }
    public override string ToString()
    {
      return "P";
    }
    private bool podeMover(Posicao pos)
    {
      Peca p = tab.peca(pos);
      return p == null || p.cor != cor;
    }
    public override bool[,] movimentosPossiveis()
    {
      bool[,] mat = new bool[tab.linhas, tab.colunas];

      Posicao pos = new Posicao(posicao.linha, posicao.coluna);
      if (tab.peca(pos).cor == Cor.Branca)
      {
        // Acima Branca
        pos.definirValores(posicao.linha - 1, posicao.coluna);
        if (tab.posicaoValida(pos) && podeMover(pos))
        {
          mat[pos.linha, pos.coluna] = true;
        }
        // Nordeste Branca
        pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
        if (tab.posicaoValida(pos) && podeMover(pos))
        {
          mat[pos.linha, pos.coluna] = true;
        }
        // Sudoeste Branca
        pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
        if (tab.posicaoValida(pos) && podeMover(pos))
        {
          mat[pos.linha, pos.coluna] = true;
        }
      }
      else
      {
        // Acima Preta
        pos.definirValores(posicao.linha + 1, posicao.coluna);
        if (tab.posicaoValida(pos) && podeMover(pos))
        {
          mat[pos.linha, pos.coluna] = true;
        }
        // Noroeste Preta
        pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
        if (tab.posicaoValida(pos) && podeMover(pos))
        {
          mat[pos.linha, pos.coluna] = true;
        }
        // Sudeste Preta
        pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
        if (tab.posicaoValida(pos) && podeMover(pos))
        {
          mat[pos.linha, pos.coluna] = true;
        }
      }
      return mat;
    }
  }
}
