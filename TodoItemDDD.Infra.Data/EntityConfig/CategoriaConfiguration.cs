using System.Data;
using System.Data.Entity.ModelConfiguration;
using TodoItemDDD.Domain.Entities;

namespace TodoItemDDD.Infra.Data.EntityConfig
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            HasKey(c => c.CategoriaId);

            Property(c => c.NomeCategoria)
                .IsRequired()
                .HasMaxLength(150);

            

        }

    }
}