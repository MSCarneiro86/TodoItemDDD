using AutoMapper;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.MVC.ViewModels;

namespace TodoItemDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
       protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<ProdutoViewModel, Produto>();
            Mapper.CreateMap<ClienteEnderecoViewModel, Cliente>();
            Mapper.CreateMap<ClienteEnderecoViewModel, Endereco>();
            Mapper.CreateMap<EnderecoViewModel, Endereco>();
            Mapper.CreateMap<CategoriaViewModel, Categoria>();
        }
    }
}
