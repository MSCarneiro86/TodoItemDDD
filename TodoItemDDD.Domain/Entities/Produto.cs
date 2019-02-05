using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TodoItemDDD.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string CodigoProdutoCliente { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Disponivel { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Imagem { get; set; }
        public string Unidade { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual List<Categoria> Categorias { get; set; }
    }
}