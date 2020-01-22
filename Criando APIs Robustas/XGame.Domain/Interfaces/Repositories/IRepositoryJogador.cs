using System;
using System.Collections.Generic;
using System.Text;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);
        Guid AdicionarJogador(Jogador jogador);
    }
}
