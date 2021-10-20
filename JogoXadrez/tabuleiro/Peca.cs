namespace tabuleiro
{
  public abstract class Peca
  {
    public Posicao Posicao { get; set; }
    public Cor Cor { get; protected set; }
    public int QtdMovimentos { get; protected set; }
    public Tabuleiro Tab { get; protected set; }

    public Peca(Tabuleiro tab, Cor cor)
    {
      this.Posicao = null;
      this.Tab = tab;
      this.Cor = cor;
      this.QtdMovimentos = 0;
    }

    public void IncrementarQtdMovimento(){
      QtdMovimentos++;
    }

    public void DecrementarQtdMovimento(){
      QtdMovimentos--;
    }

    public bool ExisteMovimentosPossíveis(){
      bool[,] mat = MovimentosPossiveis();
      for (int i=0; i< Tab.Linhas; i++){
        for(int j=0; j<Tab.Colunas; j++){
          if(mat[i,j]){
            return true;
          }
        }
      }
      return false;
    }

    public bool MovimentoPossivel(Posicao pos){
      return MovimentosPossiveis()[pos.Linha,pos.Coluna];
    }

    public abstract bool[,] MovimentosPossiveis();

    }
}