using System;
using System.Collections.Generic;
using System.Linq;
using TodoItemDDD.Application.Interface;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.Domain.Interfaces.Services;


namespace TodoItemDDD.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>,IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
        :base(clienteService)
        {
            _clienteService = clienteService;
        }

        public IEnumerable<Endereco> ListarEnderecos()
        {
           return _clienteService.GetAll().Select(c => c.Endereco).ToList();
        }
    }
}