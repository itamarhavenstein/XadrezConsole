using tabuleiro;

namespace xadrez
{
  public class Peao : Peca
  {
    public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) { }

    public override string ToString()
    {
      return "P";
    }

    private bool ExisteInimigo(Posicao pos)
    {
      Peca p = Tab.Parts(pos);
      return p != null && p.Cor != Cor;
    }

    private bool Livre(Posicao pos)
    {
      return Tab.Parts(pos) == null;
    }

    public override bool[,] MovimentosPossiveis()
    {
      bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

      Posicao pos = new Posicao(0, 0);

      if (Cor == Cor.Branca)
      {
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
        if (Tab.PosicaoValida(pos) && Livre(pos))
        {
          mat[pos.Linha, pos.Coluna] = true;
        }

        pos.DefinirValores(pos.Linha - 2, pos.Coluna);
        if (Tab.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
        {
          mat[pos.Linha, pos.Coluna] = true;
        }

        pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
        if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
        {
          mat[pos.Linha, pos.Coluna] = true;
        }

        pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
        if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
        {
          mat[pos.Linha, pos.Coluna] = true;
        }
      }
      else
      {
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
        if (Tab.PosicaoValida(pos) && Livre(pos))
        {
          mat[pos.Linha, pos.Coluna] = true;
        }

        pos.DefinirValores(pos.Linha + 2, pos.Coluna);
        if (Tab.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
        {
          mat[pos.Linha, pos.Coluna] = true;
        }

        pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
        if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
        {
          mat[pos.Linha, pos.Coluna] = true;
        }

        pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
        if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
        {
          mat[pos.Linha, pos.Coluna] = true;
        }
      }
      return mat;
    }
  }
}