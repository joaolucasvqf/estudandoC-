using Microsoft.EntityFrameworkCore;
using MimicAPI.Database;
using MimicAPI.Helpers;
using MimicAPI.V1.Models;
using MimicAPI.V1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimicAPI.V1.Repositories
{
    public class PalavraRepository : IPalavraRepository
    {
        private readonly MimicContext _banco;
        public PalavraRepository(MimicContext banco)
        {
            _banco = banco;
        }
        public PaginationList<Palavra> ObterPalavras(PalavraUrlQuery query)
        {
            var lista = new PaginationList<Palavra>();
            var item = _banco.Palavras.AsNoTracking().AsQueryable();
            if (query.Data.HasValue)
            {
                item = item.Where(a => a.Criado >= query.Data.Value || a.Atualizado >= query.Data.Value);
            }

            if (query.PagNum.HasValue)
            {
                var qtdTotalRegistros = item.Count();
                item = item.Skip((query.PagNum.Value - 1) * query.RegPerPag.Value).Take(query.RegPerPag.Value);

                var paginacao = new Paginacao();
                paginacao.PagNum = query.PagNum.Value;
                paginacao.RegPerPag = query.RegPerPag.Value;
                paginacao.RegistersTotal = qtdTotalRegistros;
                paginacao.PagesTotal = (int)Math.Ceiling((double)qtdTotalRegistros / query.RegPerPag.Value);

                lista.Paginacao = paginacao;
            }

            lista.Results.AddRange(item.ToList());

            return lista;
        }
        public Palavra Obter(int id)
        {
            return _banco.Palavras.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }
        public void Cadastrar(Palavra palavra)
        {
            _banco.Palavras.Add(palavra);
            _banco.SaveChanges();
        }
        public void Atualizar(Palavra palavra)
        {
            _banco.Palavras.Update(palavra);
            _banco.SaveChanges();
        }
        public void Deletar(int id)
        {
            var palavra = Obter(id);
            palavra.Ativo = false;
            _banco.Palavras.Update(palavra);
            _banco.SaveChanges();
        }
    }
}
