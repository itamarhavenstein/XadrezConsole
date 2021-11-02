using tabuleiro;

namespace xadrez
{
  public class Torre : Peca
  {
    public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) { }

    public override string ToString()
    {
      return "T";
    }

    private bool PodeMover(Posicao pos)
    {
      Peca p = Tab.Parts(pos);
      return p == null || p.Cor != Cor;
    }

    public override bool[,] MovimentosPossiveis()
    {
      bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

      Posicao pos = new Posicao(0, 0);

      //acima
      pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
        if (Tab.Parts(pos) != null && Tab.Parts(pos).Cor != Cor)
        {
          break;
        }
        pos.Linha = pos.Linha - 1;
      }

      //abaixo
      pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
        if (Tab.Parts(pos) != null && Tab.Parts(pos).Cor != Cor)
        {
          break;
        }
        pos.Linha = pos.Linha + 1;
      }

      //direita
      pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
        if (Tab.Parts(pos) != null && Tab.Parts(pos).Cor != Cor)
        {
          break;
        }
        pos.Coluna = pos.Coluna + 1;
      }

      //esquerda
      pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
        if (Tab.Parts(pos) != null && Tab.Parts(pos).Cor != Cor)
        {
          break;
        }
        pos.Coluna = pos.Coluna - 1;
      }
      
      return mat;
    }
  }
}