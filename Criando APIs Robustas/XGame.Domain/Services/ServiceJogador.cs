using System;
using System.Collections.Generic;
using System.Text;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;

namespace XGame.Domain.Services
{
    public class ServiceJogador : IServiceJogador
    {
        private readonly IRepositoryJogador _repository;
        public ServiceJogador(IRepositoryJogador repository)
        {
            _repository = repository;
        }
        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            Jogador jogador = new Jogador(request);
            var id = _repository.AdicionarJogador(jogador);

            return new AdicionarJogadorResponse()
            {
                Id = id,
                Mensagem = "Operação realizada com sucesso!!!"
            };
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                throw new Exception("Os dados informados estão incorretos!");
            }
            var response = _repository.AutenticarJogador(request);
            return response;
        }
    }
}
