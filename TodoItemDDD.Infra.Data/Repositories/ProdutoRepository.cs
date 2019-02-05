using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.Domain.Interfaces.Repositories;

namespace TodoItemDDD.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return Db.Produtos.Where(p => p.Descricao == nome || p.Marca == nome || p.Modelo == nome);
        }

        public IEnumerable<Categoria> ListarCategorias(int[] splCategorias)
        {
            return Db.Categorias.Where(w => splCategorias.Contains(w.CategoriaId));
        }
        
    }
}