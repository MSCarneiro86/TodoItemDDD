using System;
using System.Collections.Generic;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.Domain.Interfaces.Repositories;
using TodoItemDDD.Domain.Interfaces.Services;

namespace TodoItemDDD.Domain.Services
{
    public class EnderecoService : ServiceBase<Endereco>, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
            :base(enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

       

    }
    
        
 }