using Microsoft.AspNetCore.Identity;
using MinhasTarefasAPI.Models;

namespace MinhasTarefasAPI.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
        void Cadastrar(IdentityUser usuario, string senha);
        IdentityUser Obter(string email, string senha);
    }
}
