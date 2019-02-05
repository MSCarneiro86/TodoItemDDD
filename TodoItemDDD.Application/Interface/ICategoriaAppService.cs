using System.Collections.Generic;
using TodoItemDDD.Domain.Entities;

namespace TodoItemDDD.Application.Interface
{
    public interface ICategoriaAppService : IAppServiceBase<Categoria>
    {
        IEnumerable<Categoria> BuscarId(int[] splCategorias);
        IEnumerable<Categoria> ListaCategoriasPai();
        IEnumerable<Categoria> ListaCategoriasFilho(int id);
    }
}