﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TalkToApi.V1.Models;
using TalkToApi.V1.Models.DTO;
using TalkToApi.V1.Repositories.Contracts;

namespace TalkToApi.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public UsuarioController(IMapper mapper, IUsuarioRepository usuarioRepository, ITokenRepository tokenRepository, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        [HttpGet("", Name = "UsuarioObterTodos")]
        public ActionResult ObterTodos()
        {
            var usuariosAppUsers = _userManager.Users.ToList();

            var listaUsuariosDTO = _mapper.Map<List<ApplicationUser>, List<UsuarioDTO>>(usuariosAppUsers);

            foreach (var usuarioDTO in listaUsuariosDTO)
            {
                usuarioDTO.Links.Add(
                    new LinkDTO("_self", Url.Link("UsuarioObter", new { id = usuarioDTO.Id }), "GET"));
            }

            var lista = new ListaDTO<UsuarioDTO>() { Lista = listaUsuariosDTO };
            lista.Links.Add(
                new LinkDTO("_self", Url.Link("UsuarioObterTodos", null), "GET"));

            return Ok(lista);
        }

        [HttpGet("{id}", Name = "UsuarioObter")]
        public ActionResult ObterUsuario(string id)
        {
            var usuario = _userManager.FindByIdAsync(id).Result;

            if (usuario == null)
                return NotFound();

            var usuarioDTOdb = _mapper.Map<ApplicationUser, UsuarioDTO>(usuario);
            usuarioDTOdb.Links.Add(
                new LinkDTO("_self", Url.Link("UsuarioObter", new { id = usuario.Id }), "GET"));
            usuarioDTOdb.Links.Add(
                new LinkDTO("_atualizar", Url.Link("UsuarioAtualizar", new { id = usuario.Id }), "PUT"));

            return Ok(usuario);
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]UsuarioDTO usuarioDTO)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("ConfirmacaoSenha");

            if (ModelState.IsValid)
            {
                ApplicationUser usuario = _usuarioRepository.Obter(usuarioDTO.Email, usuarioDTO.Senha);
                if (usuario != null)
                {
                    //Login no Identity
                    _signInManager.SignInAsync(usuario, false);


                    //retorna o Token (JWT)
                    return GerarToken(usuario);
                }
                else
                {
                    return NotFound("Usuário não localizado!");
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
            var refreshTokenDB = _tokenRepository.Obter(tokenDTO.RefreshToken);

            if (refreshTokenDB == null)
                return NotFound();

            //RefreshToken antigo - Atualizar - Desativar esse refreshToken
            refreshTokenDB.DataAtualzacao = DateTime.Now;
            refreshTokenDB.Utilizado = true;
            _tokenRepository.Atualizar(refreshTokenDB);

            //Gerar um novo Token/Refresh Token - Salvar.
            var usuario = _usuarioRepository.Obter(refreshTokenDB.UsuarioId);

            return GerarToken(usuario);
        }

        [HttpPost("", Name = "UsuarioCadastrar")]
        public ActionResult Cadastrar([FromBody]UsuarioDTO usuarioDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser usuario = _mapper.Map<UsuarioDTO, ApplicationUser>(usuarioDTO);

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
                    var usuarioDTOdb = _mapper.Map<ApplicationUser, UsuarioDTO>(usuario);
                    usuarioDTOdb.Links.Add(
                        new LinkDTO("_self", Url.Link("UsuarioCadastrar", new { id = usuario.Id }), "POST"));
                    usuarioDTOdb.Links.Add(
                        new LinkDTO("_obter", Url.Link("UsuarioObter", new { id = usuario.Id }), "GET"));
                    usuarioDTOdb.Links.Add(
                        new LinkDTO("_atualizar", Url.Link("UsuarioAtualizar", new { id = usuario.Id }), "PUT"));

                    return Ok(usuarioDTOdb);
                }

            }
            else
            {
                return UnprocessableEntity(ModelState);
            }
        }

        /*
         * api/usuario/{id} -> PUT
         */
        //[Authorize]
        [HttpPut("{id}", Name = "UsuarioAtualizar")]
        public ActionResult Atualizar(string id, [FromBody]UsuarioDTO usuarioDTO)
        {
            //TODO - Adicionar Filtro de Validação
            ApplicationUser usuario = _userManager.GetUserAsync(HttpContext.User).Result;
            if (usuario.Id != id)
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                //TODO - Refatorar para AutoMapper.
                usuario.FullName = usuarioDTO.Nome;
                usuario.UserName = usuarioDTO.Email;
                usuario.Email = usuarioDTO.Email;
                usuario.Slogan = usuarioDTO.Slogan;

                //TODO - Remover no Identity critérios da senha.
                var resultado = _userManager.UpdateAsync(usuario).Result;
                _userManager.RemovePasswordAsync(usuario);
                _userManager.AddPasswordAsync(usuario, usuarioDTO.Senha);

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
                    var usuarioDTOdb = _mapper.Map<ApplicationUser, UsuarioDTO>(usuario);
                    usuarioDTOdb.Links.Add(
                        new LinkDTO("_self", Url.Link("UsuarioAtualizar", new { id = usuario.Id }), "PUT"));
                    usuarioDTOdb.Links.Add(
                        new LinkDTO("_obter", Url.Link("UsuarioObter", new { id = usuario.Id }), "GET"));

                    return Ok(usuario);
                }
            }
            else
            {
                return UnprocessableEntity(ModelState);
            }
        }

        private TokenDTO BuildToken(ApplicationUser usuario)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("chave-api-jwt-minhas-tarefas")); //Recomendo -> appsettings.json
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
            var expRefreshToken = DateTime.UtcNow.AddHours(2);

            var tokenDTO = new TokenDTO { Token = tokenString, Expiration = exp, RefreshToken = refreshToken, ExpirationRefreshToken = expRefreshToken };

            return tokenDTO;
        }

        private ActionResult GerarToken(ApplicationUser usuario)
        {
            var token = BuildToken(usuario);

            //Salvar o Token no Banco
            var tokenModel = new Token()
            {
                RefreshToken = token.RefreshToken,
                ExpirationToken = token.Expiration,
                ExpirationRefreshToken = token.ExpirationRefreshToken,
                Usuario = usuario,
                Utilizado = false
            };

            _tokenRepository.Cadastrar(tokenModel);
            return Ok(token);
        }
    }
}