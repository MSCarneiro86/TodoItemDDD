using System.Data.Entity.ModelConfiguration;
using TodoItemDDD.Domain.Entities;

namespace TodoItemDDD.Infra.Data.EntityConfig
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            HasKey(c => c.EnderecoId);

            Property(c => c.Cep)
                .IsRequired();

            Property(c => c.Logradouro)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(30);

            Property(c => c.Complemento)
                .IsOptional()
                .HasMaxLength(100);

            Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(30);

            Property(c => c.Cidade)
                .IsRequired()
                .HasMaxLength(30);

            Property(c => c.Estado)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}