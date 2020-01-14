using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MinhasTarefasAPI.Models;
using MinhasTarefasAPI.Repositories.Contracts;
using Newtonsoft.Json;

namespace MinhasTarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public TarefasController(ITarefaRepository tarefaRepository, UserManager<ApplicationUser> userManager)
        {
            _tarefaRepository = tarefaRepository;
            _userManager = userManager;

        }
        [HttpGet("")]
        public ActionResult Modelo()
        {
            return Ok(new Tarefa());
        }
        [Authorize]
        [HttpPost("sincronizar")]
        public ActionResult Sincronizar([FromBody]List<Tarefa> tarefas)
        {
            return Ok(_tarefaRepository.Sincronizacao(tarefas));
        }
        [Authorize]
        [HttpGet("restaurar")]
        public ActionResult Restaurar(DateTime data)
        {
            var usuario = _userManager.GetUserAsync(HttpContext.User).Result;

            return Ok(_tarefaRepository.Restauracao(usuario, data));
        }
    }
}