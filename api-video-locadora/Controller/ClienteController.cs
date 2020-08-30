using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using api_video_locadora.Application.Interfaces;
using api_video_locadora.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_video_locadora.Controller
{
    [Produces("application/json")]

    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet(Name = "ListarCliente")]
        [ProducesResponseType(typeof(IEnumerable<Cliente>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IEnumerable<Cliente> ListarCliente()
        {
            return _clienteAppService.ListarCliente();
        }


        [HttpGet(Name = "BuscarClientePorId")]
        [ProducesResponseType(typeof(Cliente), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public Cliente BuscarClientePorId([FromQuery] long cpf)
        {
            return _clienteAppService.BuscarClientePorId(cpf);
        }

        [HttpPost(Name = "CadastrarCliente")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public string CadastrarCliente([FromBody] Cliente cliente)
        {
            return _clienteAppService.CadastrarCliente(cliente);

        }

        [HttpPost("{cpf}", Name = "DeletarCliente")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public string DeletarCliente([FromRoute] long cpf)
        {
            return _clienteAppService.DeletarCliente(cpf);

        }

    }
}


