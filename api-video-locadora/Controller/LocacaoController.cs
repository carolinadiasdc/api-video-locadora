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

    [Route("api/locacoes")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {

        private readonly ILocacaoAppService _locacaoAppService;

        public LocacaoController(ILocacaoAppService locacaoAppService)
        {
            _locacaoAppService = locacaoAppService;
        }

        [HttpGet(Name = "ListarTodasLocacoes")]
        [ProducesResponseType(typeof(IEnumerable<Locacao>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IEnumerable<Locacao> ListarFilmes()
        {
            return _locacaoAppService.ListarTodasLocacoes();
        }


        [HttpGet(Name = "BuscarLocacaoPorId")]
        [ProducesResponseType(typeof(Locacao), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public Locacao BuscarLocacaoPorId([FromQuery] long clientCpf, [FromQuery] int filmeId, [FromQuery] DateTime dataInicio)
        {
            return _locacaoAppService.BuscarLocacaoPorId(clientCpf, filmeId, dataInicio);
        }

        [HttpPost(Name = "CadastrarNovaLocacao")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public string CadastrarNovaLocacao([FromBody] Models.Locacao locacao)
        {
            return _locacaoAppService.CadastrarNovaLocacao(locacao.clienteCpf, locacao.filmeId, locacao.periodo);

        }

        [HttpPost(Name = "DevolverFilme")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public string DevolverFilme([FromBody] Models.Devolucao locacao)
        {
            return _locacaoAppService.DevolverFilme(locacao.clienteCpf, locacao.filmeId, locacao.dataLocacao);

        }

    }
}

