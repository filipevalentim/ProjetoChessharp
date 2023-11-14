using tabuleiro;

namespace xadrez
{
  class PartidaDeXadrez
  {
    public Tabuleiro tab { get; private set; }
    public int turno { get; private set; }
    public Cor jogadorAtual { get; private set; }
    public bool terminada { get; private set; }
    //private HashSet<Peca> pecas;
    //private HashSet<Peca> capturadas;
    private HashSet<Peca> pecas = new HashSet<Peca>();
    private HashSet<Peca> capturadas = new HashSet<Peca>();
    public PartidaDeXadrez()
    {
      tab = new Tabuleiro(8, 8);
      turno = 1;
      jogadorAtual = Cor.Branca;
      terminada = false;
      colocarPecas();
      //pecas = new HashSet<Peca>();
      //capturadas = new HashSet<Peca>();
    }
    public void executaMovimento(Posicao origem, Posicao destino)
    {
      Peca p = tab.retirarPeca(origem);
      p.incrementarQteMovimentos();
      Peca pecaCapturada = tab.retirarPeca(destino);
      tab.colocarPeca(p, destino);
      if (pecaCapturada != null)
      {
        capturadas.Add(pecaCapturada);
      }
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
    public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
    {
      if (!tab.peca(origem).podeMoverPara(destino))
      {
        throw new TabuleiroException("Posição de destino inválida!");
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
    public HashSet<Peca> pecasCapturadas(Cor cor) 
    {
      HashSet<Peca> aux = new HashSet<Peca>();
      foreach (Peca x in capturadas)
      {
        if (x.cor == cor)
        {
          aux.Add(x);
        }
      }
      return aux;
    }
    public HashSet<Peca> pecasEmJogo(Cor cor) 
    {
      HashSet<Peca> aux = new HashSet<Peca>();
      foreach (Peca x in capturadas)
      {
        if (x.cor == cor)
        {
          aux.Add(x);
        }
      }
      aux.ExceptWith(pecasCapturadas(cor));
      return aux;
    }
    public void colocarNovaPeca(char coluna, int linha, Peca peca)
    {
      tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
      pecas.Add(peca);
    }
    public void colocarNovoPeao(int linha, int coluna, Peca peca)
    {
      tab.colocarPeca(peca, new Posicao(linha, coluna));
      pecas.Add(peca);
    }
    private void colocarPecas()
    {
      colocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
      colocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preta));
      colocarNovaPeca('c', 8, new Bispo(tab, Cor.Preta));
      colocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));
      colocarNovaPeca('e', 8, new Dama(tab, Cor.Preta));
      colocarNovaPeca('f', 8, new Bispo(tab, Cor.Preta));
      colocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preta));
      colocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));

      for (int i = 0; i < tab.linhas; i++)
      {
        //tab.colocarPeca(new Peao(tab, Cor.Preta), new Posicao(1, i));
        //tab.colocarPeca(new Peao(tab, Cor.Branca), new Posicao(6, i));

        //colocarNovaPeca(i, 7, new Peao(tab, Cor.Preta));
        //colocarNovaPeca(i, 2, new Peao(tab, Cor.Branca));

        colocarNovoPeao(1, i, new Peao(tab, Cor.Preta));
        colocarNovoPeao(6, i, new Peao(tab, Cor.Branca));
      }

      colocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
      colocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
      colocarNovaPeca('c', 1, new Bispo(tab, Cor.Branca));
      colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));
      colocarNovaPeca('e', 1, new Dama(tab, Cor.Branca));
      colocarNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
      colocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
      colocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));
    }
  }
}