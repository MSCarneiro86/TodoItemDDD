using AutoMapper;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.MVC.ViewModels;

namespace TodoItemDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
       
        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Produto, ProdutoViewModel>();
            Mapper.CreateMap<Cliente, ClienteEnderecoViewModel>();
            Mapper.CreateMap<Endereco, ClienteEnderecoViewModel>();            
            Mapper.CreateMap<Endereco, EnderecoViewModel>();
            Mapper.CreateMap<Categoria, CategoriaViewModel>();

        }
    }
}


