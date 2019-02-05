using System.Collections.Generic;
using TodoItemDDD.Application.Interface;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.Domain.Interfaces.Services;

namespace TodoItemDDD.Application
{
    public class EnderecoAppService : AppServiceBase<Endereco>, IEnderecoAppService
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoAppService(IEnderecoService enderecoService) 
            : base(enderecoService)
        {
            _enderecoService = enderecoService;
        }
        
    }
}