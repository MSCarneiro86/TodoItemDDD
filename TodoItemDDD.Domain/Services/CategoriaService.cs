using System;
using System.Collections.Generic;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.Domain.Interfaces.Repositories;
using TodoItemDDD.Domain.Interfaces.Services;

namespace TodoItemDDD.Domain.Services
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
            :base(categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IEnumerable<Categoria> BuscarId(int[] splCategorias)
        {
            return _categoriaRepository.BuscarId(splCategorias);
        }

        public IEnumerable<Categoria> ListaCategoriasFilho(int id)
        {
            return _categoriaRepository.ListaCategoriasFilho(id);
        }

        public IEnumerable<Categoria> ListaCategoriasPai()
        {
            return _categoriaRepository.ListaCategoriasPai();
        }
    }
}