using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoItemDDD.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Razão Social")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o campo Contato")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Contato { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MaxLength(100, ErrorMessage = "Maximo {0} caracteres")]
        [DisplayName("CNPJ")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Maximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um email válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(100, ErrorMessage = "Maximo {0} caracteres")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [ScaffoldColumn(false)] public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }       

        public EnderecoViewModel EnderecoViewModel { get; set; }
    
        public ICollection<ProdutoViewModel> ProdutoViewModel { get; set; }
    }
}
