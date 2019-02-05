using System;
using System.Collections.Generic;
using TodoItemDDD.Application.Interface;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.Domain.Interfaces.Services;

namespace TodoItemDDD.Application
{
    public class CategoriaAppService : AppServiceBase<Categoria>, ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaAppService(ICategoriaService categoriaService) 
            : base(categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public IEnumerable<Categoria> BuscarId(int[] splCategorias)
        {
            return _categoriaService.BuscarId(splCategorias);
        }

        public IEnumerable<Categoria> ListaCategoriasFilho(int id)
        {
            return _categoriaService.ListaCategoriasFilho(id);
        }

        public IEnumerable<Categoria> ListaCategoriasPai()
        {
            return _categoriaService.ListaCategoriasPai();
        }
    }
}