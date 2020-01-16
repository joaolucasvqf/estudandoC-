using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TalkToApi.V1.Models;
using TalkToApi.V1.Repositories.Contracts;

namespace TalkToApi.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public UsuarioController(IUsuarioRepository usuarioRepository, ITokenRepository tokenRepository, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _usuarioRepository = usuarioRepository;
            _tokenRepository = tokenRepository;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody]UsuarioDTO usuarioDTO)
        {
            ModelState.Remove("ConfirmacaoSenha");
            ModelState.Remove("Nome");

            if (ModelState.IsValid)
            {
                ApplicationUser usuario = _usuarioRepository.Obter(usuarioDTO.Email, usuarioDTO.Senha);

                if (usuario != null)
                {
                    //_signInManager.SignInAsync(usuario, false);
                    return GerarToken(usuario);
                }
                else
                {
                    return NotFound("Usuário não encontrado!");
                }
            }
            else
            {
                return UnprocessableEntity(ModelState);
            }
        }
        [HttpPost("renovar")]
        public ActionResult Renovar([FromBody]TokenDTO tokenDTO)
        {
            var refreshTokenDb = _tokenRepository.obter(tokenDTO.RefreshToken);
            if (refreshTokenDb == null)
                return NotFound();

            refreshTokenDb.DataAtualzacao = DateTime.Now;
            refreshTokenDb.Utilizado = true;
            _tokenRepository.Atualizar(refreshTokenDb);

            var usuario = _usuarioRepository.Obter(refreshTokenDb.UsuarioId);

            return GerarToken(usuario);
        }
        [HttpPost("")]
        public ActionResult Cadastrar([FromBody]UsuarioDTO usuarioDTO)
        {
            if (ModelState.IsValid)
            {
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
            else
            {
                return UnprocessableEntity(ModelState);
            }
        }
        public TokenDTO BuildToken(ApplicationUser usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("chave-api-jwt-minhas-tarefas"));
            var sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var exp = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: exp,
                signingCredentials: sign
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            var refreshToken = Guid.NewGuid().ToString();
            var expRefeshToken = DateTime.UtcNow.AddHours(2);

            var tokenDTO = new TokenDTO { Token = tokenString, Expiration = exp, RefreshToken = refreshToken, ExpirationRefreshToken = expRefeshToken };

            return tokenDTO;
        }
        private ActionResult GerarToken(ApplicationUser usuario)
        {
            var token = BuildToken(usuario);
            var tokenModel = new Token()
            {
                RefreshToken = token.RefreshToken,
                ExpirationToken = token.Expiration,
                ExpirationRefreshToken = token.ExpirationRefreshToken,
                Usuario = usuario,
                DataCriacao = DateTime.Now,
                Utilizado = false
            };

            _tokenRepository.Cadastrar(tokenModel);

            return Ok(token);
        }
    }
}