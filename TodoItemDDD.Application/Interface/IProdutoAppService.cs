using System.Collections.Generic;
using TodoItemDDD.Domain.Entities;

namespace TodoItemDDD.Application.Interface
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
        IEnumerable<Categoria> ListarCategorias(int[] splCategorias);

    }

    
}