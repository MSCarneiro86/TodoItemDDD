using System.Collections.Generic;
using TodoItemDDD.Domain.Entities;

namespace TodoItemDDD.Domain.Interfaces.Services
{
    public interface ICategoriaService : IServiceBase<Categoria>
    {
        IEnumerable<Categoria> BuscarId(int[] splCategorias);
        IEnumerable<Categoria> ListaCategoriasPai();
        IEnumerable<Categoria> ListaCategoriasFilho(int id);

    }
}