using tabuleiro;

namespace xadrez
{
  public class Bispo : Peca
  {
    public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor) { }

    public override string ToString()
    {
      return "B";
    }

    public bool PodeMover(Posicao pos)
    {
      Peca p = Tab.Parts(pos);
      return p == null || p.Cor != Cor;
    }

    public override bool[,] MovimentosPossiveis()
    {
      bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

      Posicao pos = new Posicao(0, 0);

      //acima
      pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
        if (Tab.Parts(pos) != null && Tab.Parts(pos).Cor != Cor)
        {
          break;
        }
        pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
      }

      //abaixo
      pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
        if (Tab.Parts(pos) != null && Tab.Parts(pos).Cor != Cor)
        {
          break;
        }
        pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
      }

      //direita
      pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
        if (Tab.Parts(pos) != null && Tab.Parts(pos).Cor != Cor)
        {
          break;
        }
        pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
      }

      //esquerda
      pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
        if (Tab.Parts(pos) != null && Tab.Parts(pos).Cor != Cor)
        {
          break;
        }
        pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
      }

      return mat;
    }
  }
}