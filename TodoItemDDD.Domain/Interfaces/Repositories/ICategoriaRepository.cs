using System.Collections.Generic;
using TodoItemDDD.Domain.Entities;

namespace TodoItemDDD.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        IEnumerable<Categoria> BuscarId(int[] splCategorias);

        IEnumerable<Categoria> ListaCategoriasPai();
        IEnumerable<Categoria> ListaCategoriasFilho(int id);
    }
}