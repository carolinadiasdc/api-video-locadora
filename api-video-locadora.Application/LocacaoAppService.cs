using api_video_locadora.Application.Interfaces;
using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_video_locadora.Application
{
    public class LocacaoAppService: ILocacaoAppService
    {

        // locar um filme e devolver um filme

        //CRUD


        // Listar filmes locados
        public IEnumerable<Locacao> ListarFilmesLocados()
        {
            return new List<Locacao>();

        }

        //Locar
        public void LocarLocacao(int clienteId, int filmeId, int periodo)
        {

        }

        //Devolver
        public void DevolverLocacao(int clienteId, int filmeId)
        {

        }

    }
}
