using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_video_locadora.Domain.Interfaces
{
    public interface IFilmeRepositorio
    {
        IEnumerable<Filme> ListarTodosFilmes();
        
        Filme BuscarFilmePorId(int id);
        
        bool CadastrarNovoFilme(Filme novoFilme);

        bool DeletarFilme(int id);
        bool AtualizarStatusFilme(int id, string status);


    }
}
