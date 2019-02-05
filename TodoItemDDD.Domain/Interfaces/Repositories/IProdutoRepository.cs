using System.Collections.Generic;
using TodoItemDDD.Domain.Entities;

namespace TodoItemDDD.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
        IEnumerable<Categoria> ListarCategorias(int[] splCategorias);
    }
}