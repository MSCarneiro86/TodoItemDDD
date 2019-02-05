using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoItemDDD.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string RazaoSocial { get; set; }

        public string Contato { get; set; }

        public string Documento { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<Produto> Produtos { get; set; }

        public virtual Endereco Endereco { get; set; }
       
        
    }
}