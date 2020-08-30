using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_video_locadora.Application.Interfaces
{
    public interface IFilmeAppService
    {
        IEnumerable<Filme> ListarFilmes();
        string CadastrarFilme(Filme filme);
        string DeletarFilme(int id);
        Filme BuscarFilmePorId(int id);


    }
}

