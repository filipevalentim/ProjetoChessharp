using System.Text;

namespace Tabuleiro
{
  class Posicao
  {
    public int linha { get; set; }
    public int coluna { get; set; }
    public Posicao(int linha, int coluna)
    {
      this.linha = linha;
      this.coluna = coluna;
    }
    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append(linha);
      sb.Append(", ");
      sb.Append(coluna);
      return sb.ToString();
    }
  }
}
