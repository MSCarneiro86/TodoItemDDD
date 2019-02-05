using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.Infra.Data.EntityConfig;

namespace TodoItemDDD.Infra.Data.Contexto
{
    public class TodoItemDDDContext : DbContext
    {
        public TodoItemDDDContext()
        :base("DefaultConnection")
        {
                            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }        
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure((p => p.HasColumnType("varchar")));

            modelBuilder.Properties<string>()
                .Configure((p => p.HasMaxLength(100)));

           
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());            
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            /*foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CategoriaPaiId") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CategoriaPaiId").CurrentValue = 1;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CategoriaPaiId").IsModified = false;
                }
            }*/


            return base.SaveChanges();

        }

    }
}