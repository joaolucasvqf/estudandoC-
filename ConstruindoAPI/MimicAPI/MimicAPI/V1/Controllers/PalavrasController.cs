using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MimicAPI.Helpers;
using MimicAPI.V1.Models;
using MimicAPI.V1.Models.DTO;
using MimicAPI.V1.Repositories.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MimicAPI.V1.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1")]
    public class PalavrasController : ControllerBase
    {
        private readonly IPalavraRepository _repository;
        private readonly IMapper _mapper;
        public PalavrasController(IPalavraRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [MapToApiVersion("1.0")]
        [MapToApiVersion("1.1")]
        /// <summary>
        /// Crud com todas as palavras cadastradas no banco
        /// </summary>
        /// <param name="data">data=yyyy-mm-dd</param>
        /// <param name="pagNum">Número da página</param>
        /// <param name="RegPerPag">Quantidade de registros por página</param>
        /// <returns>Json</returns>
        [HttpGet("", Name = "ObterTodas")]
        public ActionResult ObterPalavras([FromQuery]PalavraUrlQuery query)
        {
            var item = _repository.ObterPalavras(query);
            if (item.Results.Count() == 0)
                return NotFound();

            PaginationList<PalavraDTO> lista = CriarLinksPalavraDTO(query, item);

            return Ok(lista);
            //Outra opção de retorno
            //return new JsonResult( _banco.Palavras );
        }

        private PaginationList<PalavraDTO> CriarLinksPalavraDTO(PalavraUrlQuery query, PaginationList<Palavra> item)
        {
            var lista = _mapper.Map<PaginationList<Palavra>, PaginationList<PalavraDTO>>(item);

            foreach (var palavraDTO in lista.Results)
            {
                palavraDTO.Links = new List<LinkDTO>();
                palavraDTO.Links.Add(
                    new LinkDTO("self", Url.Link("ObterPalavra", new { id = palavraDTO.Id }), "GET")
                );
            }

            lista.Links.Add(
                new LinkDTO("self", Url.Link("ObterTodas", query), "GET")
            );

            if (item.Paginacao != null)
            {
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(item.Paginacao));

                if (query.PagNum + 1 <= item.Paginacao.PagesTotal)
                {
                    var queryString = new PalavraUrlQuery() { PagNum = query.PagNum + 1, RegPerPag = query.RegPerPag, Data = query.Data };
                    lista.Links.Add(
                        new LinkDTO("next", Url.Link("ObterTodas", queryString), "GET")
                    );
                }
                if (query.PagNum - 1 > 0)
                {
                    var queryString = new PalavraUrlQuery() { PagNum = query.PagNum - 1, RegPerPag = query.RegPerPag, Data = query.Data };
                    lista.Links.Add(
                        new LinkDTO("prev", Url.Link("ObterTodas", queryString), "GET")
                    );
                }
            }

            return lista;
        }

        [MapToApiVersion("1.0")]
        [MapToApiVersion("1.1")]
        /// <summary>
        /// Pesquisa por uma palavra específica
        /// </summary>
        /// <param name="id">Id da palavra a ser pesquisada</param>
        /// <returns>Json</returns>
        [HttpGet("{id}", Name = "ObterPalavra")]
        public ActionResult Obter(int id)
        {
            var obj = _repository.Obter(id);

            if (obj == null)
                return NotFound();

            PalavraDTO palavraDTO = _mapper.Map<Palavra, PalavraDTO>(obj);
            palavraDTO.Links = new List<LinkDTO>();
            palavraDTO.Links.Add(
                new LinkDTO("self", Url.Link("ObterPalavra", new { id = palavraDTO.Id }), "GET")
            );
            palavraDTO.Links.Add(
                new LinkDTO("update", Url.Link("AtualizarPalavra", new { id = palavraDTO.Id }), "PUT")
            );
            palavraDTO.Links.Add(
                new LinkDTO("delete", Url.Link("ExcluirPalavra", new { id = palavraDTO.Id }), "DELETE")
            );

            return Ok(palavraDTO);
        }
        [MapToApiVersion("1.0")]
        [MapToApiVersion("1.1")]
        /// <summary>
        /// Cadastrar uma nova palavra
        /// </summary>
        /// <param name="palavra">Palavra a ser cadastrada</param>
        /// <returns>OkHttpResponse</returns>
        [HttpPost("", Name = "CadastrarPalavra")]
        public ActionResult Cadastrar([FromBody]Palavra palavra)
        {
            palavra.Ativo = true;
            palavra.Criado = DateTime.Now;
            _repository.Cadastrar(palavra);

            var palavraDTO =_mapper.Map<Palavra, PalavraDTO>(palavra);

            palavraDTO.Links.Add(
                new LinkDTO("self", Url.Link("ObterPalavra", new { id = palavraDTO.Id }), "GET")
            );

            return Created($"/api/palavras/{palavra.Id}", palavraDTO);
        }
        [MapToApiVersion("1.0")]
        [MapToApiVersion("1.1")]
        /// <summary>
        /// Request para atualizar uma palavra
        /// </summary>
        /// <param name="id"></param>
        /// <param name="palavra">Palavra a ser atualizada</param>
        /// <returns>OkHttpResponse</returns>
        [HttpPut("{id}", Name = "AtualizarPalavra")]
        public ActionResult Atualizar(int id, [FromBody]Palavra palavra)
        {
            var obj = _repository.Obter(id);
            if (obj == null)
                return NotFound();

            if (palavra == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            palavra.Id = id;
            palavra.Ativo = obj.Ativo;
            palavra.Criado = obj.Criado;
            palavra.Atualizado = DateTime.Now;
            _repository.Atualizar(palavra);

            var palavraDTO = _mapper.Map<Palavra, PalavraDTO>(palavra);

            palavraDTO.Links.Add(
                new LinkDTO("self", Url.Link("ObterPalavra", new { id = palavraDTO.Id }), "GET")
            );

            return Ok();
        }
        [MapToApiVersion("1.1")]
        /// <summary>
        /// Request para deleção
        /// </summary>
        /// <param name="id">Id da paravra a ser deletada</param>
        /// <returns>OkHttpResponse</returns>
        [HttpDelete("{id}", Name = "ExcluirPalavra")]
        public ActionResult Deletar(int id)
        {
            var palavra = _repository.Obter(id);

            if (palavra == null)
                return NotFound();

            _repository.Deletar(id);

            return NoContent();
        }
    }
}
