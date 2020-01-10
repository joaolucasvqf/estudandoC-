using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MinhasTarefasAPI.Models;
using MinhasTarefasAPI.Repositories.Contracts;

namespace MinhasTarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UsuarioController(IUsuarioRepository usuarioRepository, SignInManager<ApplicationUser> signInManager)
        {
            _usuarioRepository = usuarioRepository;
            _signInManager = signInManager;
        }
        public ActionResult Login([FromBody]UsuarioDTO usuarioDTO)
        {
            ModelState.Remove(usuarioDTO.ConfirmacaoSenha);
            ModelState.Remove(usuarioDTO.Nome);
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            
            ApplicationUser usuario = _usuarioRepository.Obter(usuarioDTO.Email, usuarioDTO.Senha);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado!");
            }

            _signInManager.SignInAsync(usuario, false);

            return Ok();
        }
    }
}