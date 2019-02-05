using System.Data.Entity.ModelConfiguration;
using TodoItemDDD.Domain.Entities;

namespace TodoItemDDD.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.RazaoSocial)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Contato)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Documento)
                .IsRequired()
                .HasMaxLength(15);

            Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .IsRequired();

            Property(c => c.DataCadastro)
                .IsRequired();            

            HasRequired(c => c.Endereco);


        }
        
    }
}