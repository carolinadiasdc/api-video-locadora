using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_video_locadora.Domain.Interfaces
{
    public interface IClienteRepositorio
    {
        IEnumerable<Cliente> ListarTodosClientes();
        Cliente BuscarClientePorId(long cpf);
        bool CadastrarNovoCliente(Cliente novoCliente);
        bool DeletarCliente(long cpf);

    }
}
