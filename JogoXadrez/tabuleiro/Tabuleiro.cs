namespace tabuleiro
{
  public class Tabuleiro
  {
    public int Linhas { get; set; }
    public int Colunas { get; set; }
    private Peca[,] Pecas;

    public Tabuleiro(int linhas, int colunas)
    {
      this.Linhas = linhas;
      this.Colunas = colunas;
      Pecas = new Peca[linhas, colunas];
    }

    public Peca Parts(int linha, int coluna)
    {
      return Pecas[linha, coluna];
    }

    public void ColocarPeca(Peca peca, Posicao pos)
    {
      Pecas[pos.Linha, pos.Coluna] = peca;
      peca.Posicao = pos;
    }
  }
}