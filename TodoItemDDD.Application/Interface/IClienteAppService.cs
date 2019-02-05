using System.Collections.Generic;
using TodoItemDDD.Domain.Entities;

namespace TodoItemDDD.Application.Interface
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        IEnumerable<Endereco> ListarEnderecos();
    }
}