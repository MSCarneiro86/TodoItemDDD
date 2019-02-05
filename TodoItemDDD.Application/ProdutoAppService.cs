using System;
using System.Collections.Generic;
using TodoItemDDD.Application.Interface;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.Domain.Interfaces.Services;

namespace TodoItemDDD.Application
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService)
            : base(produtoService)
        {
            _produtoService = produtoService;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoService.BuscaPorNome(nome);
        }

        public IEnumerable<Categoria> ListarCategorias(int[] splCategorias)
        {
            return _produtoService.ListarCategorias(splCategorias);
        }
    }
}