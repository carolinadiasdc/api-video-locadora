using api_video_locadora.Application.Interfaces;
using api_video_locadora.Domain.Interfaces;
using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_video_locadora.Application
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepositorio _clienteRepositorio;


        public ClienteAppService(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IEnumerable<Cliente> ListarCliente()
        {
            return _clienteRepositorio.ListarTodosClientes();
        }

        public Cliente BuscarClientePorId(long cpf)
        {
            return _clienteRepositorio.BuscarClientePorId(cpf);
        }

        public string CadastrarCliente(Cliente cliente)
        {

            Cliente bdCliente = _clienteRepositorio.BuscarClientePorId(cliente.Cpf);
            if (bdCliente == null)
            {
                bool result = _clienteRepositorio.CadastrarNovoCliente(cliente);

                if (result)
                {
                    return "Registro Inserido";
                }
                else
                {
                    return "Erro ao Inserir Registro";
                }

            }
            else
            {
                return "Cliente já existe";
            }

        }

        public string DeletarCliente(long cpf)
        {

            Cliente bdCliente = _clienteRepositorio.BuscarClientePorId(cpf);
            if (bdCliente != null)
            {
                bool result = _clienteRepositorio.DeletarCliente(bdCliente.Cpf);

                if (result)
                {
                    return "Registro Excluido";
                }
                else
                {
                    return "Erro ao Excluir Registro";
                }

            }
            else
            {
                return "Cliente já existe";
            }

        }
    }
}


