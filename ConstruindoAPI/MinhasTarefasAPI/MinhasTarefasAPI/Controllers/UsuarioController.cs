using System.Collections.Generic;
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
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public UsuarioController(IUsuarioRepository usuarioRepository, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _usuarioRepository = usuarioRepository;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody]UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return UnprocessableEntity();

            ModelState.Remove(usuarioDTO.ConfirmacaoSenha);
            ModelState.Remove(usuarioDTO.Nome);

            if (ModelState.IsValid)
            {
                IdentityUser usuario = _usuarioRepository.Obter(usuarioDTO.Email, usuarioDTO.Senha);

                if (usuario != null)
                {

                    _signInManager.SignInAsync(usuario, false);

                    return Ok();
                } else
                {
                    return NotFound("Usuário não encontrado!");
                }
            } else
            {
                return UnprocessableEntity(ModelState);
            }
        }
        [HttpPost("")]
        public ActionResult CadastrarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return UnprocessableEntity();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            ApplicationUser usuario = new ApplicationUser();
            usuario.FullName = usuarioDTO.Nome;
            usuario.UserName = usuarioDTO.Email;
            usuario.Email = usuarioDTO.Email;
            var resultado = _userManager.CreateAsync(usuario, usuarioDTO.Senha).Result;

            if (!resultado.Succeeded)
            {
                List<string> erros = new List<string>();
                foreach (var erro in resultado.Errors)
                {
                    erros.Add(erro.Description);
                }
                return UnprocessableEntity(erros);
            }
            else
            {
                return Ok(usuario);
            }
        }
    }
}