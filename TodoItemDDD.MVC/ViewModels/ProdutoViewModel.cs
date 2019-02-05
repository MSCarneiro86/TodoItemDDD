using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoItemDDD.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o Codigo do Produto do Cliente")]
        [MaxLength(250,ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Codigo do Produto")]
        public string CodigoProdutoCliente { get; set; }

        [Required(ErrorMessage = "Preencha a Descrição do Produto")]
        [MaxLength(250, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha a Marca, caso não possua digite N/D")]
        [MaxLength(250, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Marca")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Preencha o Modelo, caso não possua digite N/D")]
        [MaxLength(250, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Modelo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Imagem Requerida")]
        public string Imagem { get; set; }

        [DataType(DataType.Currency)]
        [Range(0.01, 9999.00)]
        [Required(ErrorMessage = "Preencha o valor")]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Preencha a Unidade")]
        public string Unidade { get; set; }

        [DisplayName("Disponivel?")]
        public bool Disponivel { get; set; }

        [DisplayName("Cliente")]
        public int ClienteId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }

        public List<CategoriaViewModel> Categorias { get; set; }
       
    }
}







