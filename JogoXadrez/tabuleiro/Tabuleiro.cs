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

    public Peca RetirarPeca(Posicao pos){
      if(Parts(pos) == null){
        return null;
      }
      Peca aux = Parts(pos);
      aux.Posicao = null;
      Pecas[pos.Linha, pos.Coluna] = null;
      return aux;
    }

    public Peca Parts(Posicao pos)
    {
      return Pecas[pos.Linha, pos.Coluna];
    }

    public void ColocarPeca(Peca peca, Posicao pos)
    {
      if(ExistePeca(pos)){
        throw new TabuleiroException("Já existe uma peça nessa posição!");
      }
      Pecas[pos.Linha, pos.Coluna] = peca;
      peca.Posicao = pos;
    }

    public bool PosicaoValida(Posicao pos)
    {
      if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
      {
        return false;
      }
      return true;
    }

    public void ValidarPosicao(Posicao pos)
    {
      if (!PosicaoValida(pos))
      {
        throw new TabuleiroException("Posição inválida");
      }
    }

    public bool ExistePeca(Posicao pos)
    {
      ValidarPosicao(pos);
      return Parts(pos) != null;
    }
  }
}