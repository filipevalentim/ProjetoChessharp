using tabuleiro;

namespace xadrez
{
  class PartidaDeXadrez
  {
    public Tabuleiro tab { get; private set; }
    public int turno { get; private set; }
    public Cor jogadorAtual { get; private set; }
    public bool terminada { get; private set; }
    public PartidaDeXadrez()
    {
      tab = new Tabuleiro(8, 8);
      turno = 1;
      jogadorAtual = Cor.Branca;
      terminada = false;
      colocarPecas();
    }
    public void executaMovimento(Posicao origem, Posicao destino)
    {
      Peca p = tab.retirarPeca(origem);
      p.incrementarQteMovimentos();
      Peca pecaCapturada = tab.retirarPeca(destino);
      tab.colocarPeca(p, destino);
    }
    public void realizarJogada(Posicao origem, Posicao destino)
    {
      executaMovimento(origem, destino);
      turno++;
      mudaJogador();
    }
    public void validarPosicaoDeOrigem(Posicao pos)
    {
      if (tab.peca(pos) == null)
      {
        throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
      }
      if (jogadorAtual != tab.peca(pos).cor)
      {
        throw new TabuleiroException("A peça de origem não é sua!");
      }
      if (!tab.peca(pos).existeMovimentosPossiveis())
      {
        throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
      }
    }
    private void mudaJogador()
    {
      if (jogadorAtual == Cor.Branca)
      {
        jogadorAtual = Cor.Preta;
      }
      else
      {
        jogadorAtual = Cor.Branca;
      }
    }
    private void colocarPecas()
    {
      tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('a', 8).toPosicao());
      tab.colocarPeca(new Cavalo(tab, Cor.Preta), new PosicaoXadrez('b', 8).toPosicao());
      tab.colocarPeca(new Bispo(tab, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
      tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).toPosicao());
      tab.colocarPeca(new Dama(tab, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
      tab.colocarPeca(new Bispo(tab, Cor.Preta), new PosicaoXadrez('f', 8).toPosicao());
      tab.colocarPeca(new Cavalo(tab, Cor.Preta), new PosicaoXadrez('g', 8).toPosicao());
      tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('h', 8).toPosicao());

      for (int i = 0; i < tab.linhas; i++)
      {
        tab.colocarPeca(new Peao(tab, Cor.Preta), new Posicao(1, i));
        tab.colocarPeca(new Peao(tab, Cor.Branca), new Posicao(6, i));
      }

      tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('a', 1).toPosicao());
      tab.colocarPeca(new Cavalo(tab, Cor.Branca), new PosicaoXadrez('b', 1).toPosicao());
      tab.colocarPeca(new Bispo(tab, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());
      tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());
      tab.colocarPeca(new Dama(tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
      tab.colocarPeca(new Bispo(tab, Cor.Branca), new PosicaoXadrez('f', 1).toPosicao());
      tab.colocarPeca(new Cavalo(tab, Cor.Branca), new PosicaoXadrez('g', 1).toPosicao());
      tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('h', 1).toPosicao());
    }
  }
}