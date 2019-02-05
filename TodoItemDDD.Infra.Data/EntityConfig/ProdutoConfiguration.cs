using System.Data.Entity.ModelConfiguration;
using TodoItemDDD.Domain.Entities;

namespace TodoItemDDD.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.ProdutoId);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(250);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(250);

            Property(p => p.Marca)
                .IsRequired()
                .HasMaxLength(250);

            Property(p => p.Modelo)
                .IsRequired()
                .HasMaxLength(250);

            Property(p => p.Unidade)
                .IsRequired()
                .HasMaxLength(250);

            Property(p => p.Preco)
                .IsRequired();

            HasRequired(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId);
            
        }
    }
}