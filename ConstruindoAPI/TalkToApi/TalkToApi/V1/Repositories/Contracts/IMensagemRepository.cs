using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalkToApi.V1.Models;

namespace TalkToApi.V1.Repositories.Contracts
{
    public interface IMensagemRepository
    {
        List<Mensagem> ObterMensagens (string usuarioUm, string usuarioDois);
        Mensagem ObterMensagem (int id);
        void Cadastrar(Mensagem mensagem);
        void Atualizar(Mensagem mensagem);
    }
}
