using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_video_locadora.Application.Interfaces
{
    public interface IClienteAppService
    {
        IEnumerable<Cliente> ListarCliente();
        string CadastrarCliente(Cliente cliente);
        string DeletarCliente(long cpf);
        Cliente BuscarClientePorId(long cpf);


    }
}
