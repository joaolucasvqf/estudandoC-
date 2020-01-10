using MinhasTarefasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasTarefasAPI.Repositories.Contracts
{
    interface IUsuarioRepository
    {
        void Cadastrar(ApplicationUser usuario);
        ApplicationUser Obter(string email, string senha);
    }
}
