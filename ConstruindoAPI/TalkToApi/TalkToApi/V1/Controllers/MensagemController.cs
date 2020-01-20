using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TalkToApi.V1.Models;
using TalkToApi.V1.Models.DTO;
using TalkToApi.V1.Repositories.Contracts;

namespace TalkToApi.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MensagemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMensagemRepository _mensagemRepository;
        public MensagemController(IMapper mapper, IMensagemRepository mensagemRepository)
        {
            _mapper = mapper;
            _mensagemRepository = mensagemRepository;
        }
        [HttpGet("{usuarioUmId}/{UsuarioDoisId}")]
        public ActionResult Obter(string usuarioUmId, string usuarioDoisId)
        {
            if (usuarioUmId == usuarioDoisId)
                return UnprocessableEntity();

            var mensagens = _mensagemRepository.ObterMensagens(usuarioUmId, usuarioDoisId);
            var listaMsg = _mapper.Map<List<Mensagem>, List<MensagemDTO>>(mensagens);

            var lista = new ListaDTO<MensagemDTO>() { Lista = listaMsg };
            lista.Links.Add(new LinkDTO("_self", Url.Link("Obter", new { usuarioUmId = usuarioUmId, usuarioDoisId = usuarioDoisId }), "GET"));

            return Ok(lista);
        }
        [HttpPost("")]
        public ActionResult Cadastrar([FromBody]Mensagem mensagem)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            try
            {
                _mensagemRepository.Cadastrar(mensagem);

                var listaMsg = _mapper.Map<Mensagem, MensagemDTO>(mensagem);
                listaMsg.Links.Add(
                    new LinkDTO("_self", Url.Link("Cadastrar", new { id = mensagem.Id }), "POST"));
                listaMsg.Links.Add(
                    new LinkDTO("_atualizar", Url.Link("Atualizar", new { id = mensagem.Id }), "PATCH"));

                return Ok(listaMsg);
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