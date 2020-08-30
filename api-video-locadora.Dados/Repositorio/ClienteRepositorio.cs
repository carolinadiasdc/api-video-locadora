using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace api_video_locadora.Dados.Repositorio
{
    public class ClienteRepositorio
    {
        private List<Cliente> clientes;


        public ClienteRepositorio()
        {

            clientes = new List<Cliente>
        {
            new Cliente (11111111111,"Ana","(11) 999999999", "email@gmail.com", true),
            new Cliente (22222222222, "Carolina", "(11) 999999999", "email@gmail.com", true),
            new Cliente (33333333333, "Don Corleone","(11) 999999999", "email@gmail.com", true),
            new Cliente (44444444444, "Obi Wan", "(11) 999999999","email@gmail.com", true)

        };

        }

        public IEnumerable<Cliente> ListarTodosClientes()
        {
            return clientes;

        }
        public Cliente BuscarClientePorId(long cpf)
        {
            return clientes.Where(cliente => cliente.Cpf == cpf && cliente.Ativo == true).FirstOrDefault();

        }

        public bool CadastrarNovoCliente(Cliente novoCliente)
        {

            Cliente clientesRepetidos = BuscarClientePorId(novoCliente.Cpf);
            if (clientesRepetidos == null)
            {

                clientes.Add(novoCliente);
                return true;
            }
            else
            {
                return false;

            }

        }

        public bool DeletarCliente(long cpf)
        {
            Cliente cliente = BuscarClientePorId(cpf);

            if (cliente != null && cliente.Ativo == true)
            {
                clientes.Remove(cliente);
                cliente.Ativo = false;
                clientes.Add(cliente);

                return true;
            }

            else
            {
                return false;
            }

        }

    }

}