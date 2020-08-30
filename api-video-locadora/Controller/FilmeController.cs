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

    [Route("api/filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        private readonly IFilmeAppService _filmeAppService;

        public FilmeController(IFilmeAppService filmeAppService)
        {
            _filmeAppService = filmeAppService;
        }

        [HttpGet(Name = "ListarFilmes")]
        [ProducesResponseType(typeof(IEnumerable<Filme>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IEnumerable<Filme> ListarFilmes()
        {
            return _filmeAppService.ListarFilmes();
        }


        [HttpGet(Name = "BuscarFilmePorId")]
        [ProducesResponseType(typeof(Filme), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public Filme BuscarFilmePorId([FromQuery] int id)
        {
            return _filmeAppService.BuscarFilmePorId(id);
        }

        [HttpPost(Name = "CadastrarFilme")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public string CadastrarFilme([FromBody] Filme filme)
        {
            return _filmeAppService.CadastrarFilme(filme);

        }

        [HttpPost("{id}", Name = "DeletarFilme")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public string DeletarFilme([FromRoute] int id)
        {
            return _filmeAppService.DeletarFilme(id);

        }

    }
}
