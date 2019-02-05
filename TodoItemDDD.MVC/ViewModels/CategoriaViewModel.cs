using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TodoItemDDD.Domain.Entities;

namespace TodoItemDDD.MVC.ViewModels
{
    public class CategoriaViewModel
    {
       
       [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Razão Social")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string NomeCategoria { get; set; }

        public bool Habilitado { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }
        
        public Categoria CategoriaPai { get; set; }
        
        public int? CategoriaPaiId { get; set; }

        public ICollection<Categoria> CateogirasFilho { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}

