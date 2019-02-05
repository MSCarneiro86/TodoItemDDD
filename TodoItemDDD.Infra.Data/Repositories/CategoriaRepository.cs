using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.Domain.Interfaces.Repositories;

namespace TodoItemDDD.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public IEnumerable<Categoria> BuscarId(int[] splCategorias)
        {
            return Db.Categorias.Where(w => splCategorias.Contains(w.CategoriaId));
        }

        public IEnumerable<Categoria> ListaCategoriasFilho(int id)
        {
            return Db.Categorias.Where(m => m.Habilitado == true && m.CategoriaPaiId == id).ToList();
        }

        public IEnumerable<Categoria> ListaCategoriasPai()
        {
            return Db.Categorias.Where(m => m.Habilitado == true && m.CategoriaPaiId == null).ToList();
        }
    }
}