using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Enum;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador
    {
        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public string Senha { get; set; }
        public EnumSituacaoJogador Status { get; set; }

        public Jogador()
        {

        }
        public Jogador(AdicionarJogadorRequest request)
        {
            Nome = request.Nome;
            Email = request.Email;
            Status = Enum.EnumSituacaoJogador.Ativo;
        }

        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;
        }
    }
}
