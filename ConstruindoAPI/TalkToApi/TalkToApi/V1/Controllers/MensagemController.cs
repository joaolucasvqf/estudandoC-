using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TalkToApi.V1.Models;
using TalkToApi.V1.Repositories.Contracts;

namespace TalkToApi.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MensagemController : ControllerBase
    {
        private readonly IMensagemRepository _mensagemRepository;
        public MensagemController(IMensagemRepository mensagemRepository)
        {
            _mensagemRepository = mensagemRepository;
        }
        [HttpGet("{usuarioUmId}/{UsuarioDoisId}")]
        public ActionResult Obter(string usuarioUmId, string usuarioDoisId)
        {
            if (usuarioUmId == usuarioDoisId)
                return UnprocessableEntity();

            return Ok(_mensagemRepository.ObterMensagens(usuarioUmId, usuarioDoisId));
        }
        [HttpPost("")]
        public ActionResult Cadastrar([FromBody]Mensagem mensagem)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            try
            {
                _mensagemRepository.Cadastrar(mensagem);
                return Ok(mensagem);
            } 
            catch (Exception e)
            {
                return UnprocessableEntity(e);
            }
        }
        [HttpPatch("{id}")]
        public ActionResult AtualizarParcial(int id, [FromBody]JsonPatchDocument<Mensagem> jsonPatch)
        {
            if (jsonPatch == null)
                return UnprocessableEntity();

            var mensagem = _mensagemRepository.ObterMensagem(id);

            jsonPatch.ApplyTo(mensagem);
            mensagem.Atualizado = DateTime.UtcNow;

            _mensagemRepository.Atualizar(mensagem);

            return Ok(mensagem);
        }
    }
}