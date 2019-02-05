using System;
using System.Collections.Generic;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.Domain.Interfaces.Repositories;
using TodoItemDDD.Domain.Interfaces.Services;

namespace TodoItemDDD.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
            :base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> BuscaPorNome(string nome)
        {
            return _produtoRepository.BuscarPorNome(nome);
        }

        public IEnumerable<Categoria> ListarCategorias(int[] splCategorias)
        {
            return _produtoRepository.ListarCategorias(splCategorias);
        }
    }
}