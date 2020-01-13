using Microsoft.AspNetCore.Identity;
using MinhasTarefasAPI.Models;
using MinhasTarefasAPI.Repositories.Contracts;
using System;
using System.Text;

namespace MinhasTarefasAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsuarioRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IdentityUser Obter(string email, string senha)
        {
            var usuario = _userManager.FindByEmailAsync(email).Result;
            if (_userManager.CheckPasswordAsync(usuario, senha).Result)
            {
                return usuario;
            } 
            else
            {
                /*
                 * Domain Notification
                 */
                throw new Exception("Usuário ou senha incorretos");
            }
        }
        public void Cadastrar(IdentityUser usuario, string senha)
        {
            var result = _userManager.CreateAsync(usuario, senha).Result;
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var erro in result.Errors)
                {
                    sb.Append(erro.Description);
                }
                /*
                 * Domain Notification
                 */
                throw new Exception($"Falha ao cadastrar usuário {sb.ToString()}");
            }
        }
    }
}
