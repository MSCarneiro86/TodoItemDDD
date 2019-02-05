using System.Collections.Generic;
using TodoItemDDD.Domain.Entities;

namespace TodoItemDDD.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {

        IEnumerable<Produto> BuscaPorNome(string nome);
        IEnumerable<Categoria> ListarCategorias(int[] splCategorias);

    }
}