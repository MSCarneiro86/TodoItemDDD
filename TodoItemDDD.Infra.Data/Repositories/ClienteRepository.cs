using System;
using System.Collections.Generic;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.Domain.Interfaces.Repositories;

namespace TodoItemDDD.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        
    }
}