using tabuleiro;

namespace xadrez
{
  public class Rei : Peca
  {
    private PartidaDeXadrez partida;
    public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
    {
      this.partida = partida;
    }

    public override string ToString()
    {
      return "R";
    }

    private bool PodeMover(Posicao pos)
    {
      Peca p = Tab.Parts(pos);
      return p == null || p.Cor != Cor;
    }

    private bool TesteTorreParaRoque(Posicao pos)
    {
      Peca p = Tab.Parts(pos);
      return p != null && p is Torre && p.Cor == Cor && p.QtdMovimentos == 0;
    }

    public override bool[,] MovimentosPossiveis()
    {
      bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

      Posicao pos = new Posicao(0, 0);

      //acima
      pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
      }

      //nordeste
      pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
      }

      //direita
      pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
      }

      //sudeste
      pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
      }

      //abaixo
      pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
      }

      //sudoeste
      pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
      }

      //esquerda
      pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
      }

      //noroeste
      pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
      }

      //#Jogadaespecial Roque
      if (QtdMovimentos == 0 && !partida.Xeque)
      {
        //#JogadaEspecial roque pequeno
        Posicao PosT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
        if (TesteTorreParaRoque(PosT1))
        {
          Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
          Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
          if (Tab.Parts(p1) == null && Tab.Parts(p2) == null)
          {
            mat[Posicao.Linha, Posicao.Coluna + 2] = true;
          }
        }
        //#JogadaEspecial roque Grande
        Posicao PosT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
        if (TesteTorreParaRoque(PosT2))
        {
          Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
          Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
          Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
          if (Tab.Parts(p1) == null && Tab.Parts(p2) == null && Tab.Parts(p3) == null)
          {
            mat[Posicao.Linha, Posicao.Coluna - 2] = true;
          }
        }
      }

      return mat;
    }
  }
}