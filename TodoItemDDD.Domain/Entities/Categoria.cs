using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoItemDDD.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required]
        public string NomeCategoria  { get; set; }
        public int? CategoriaPaiId { get; set; }
        public bool Habilitado { get; set; }
        [Required]
        public string Action { get; set; }
        [Required]
        public string Controller { get; set; }

        [ForeignKey("CategoriaPaiId")]
        public virtual Categoria CategoriaPai { get; set; }
        public virtual IList<Produto> Produtos { get; set; }
        public virtual ICollection<Categoria> CateogirasFilho { get; set; }

    }
}