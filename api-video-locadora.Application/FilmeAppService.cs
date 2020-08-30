using api_video_locadora.Application.Interfaces;
using api_video_locadora.Domain.Interfaces;
using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_video_locadora.Application
{
    public class FilmeAppService : IFilmeAppService
    {
        private readonly IFilmeRepositorio _filmeRepositorio;


        public FilmeAppService(IFilmeRepositorio filmeRepositorio)
        {
            _filmeRepositorio = filmeRepositorio;
        }

        public IEnumerable<Filme> ListarFilmes()
        {
            return _filmeRepositorio.ListarTodosFilmes();
        }

        public Filme BuscarFilmePorId(int id)
        {
            return _filmeRepositorio.BuscarFilmePorId(id);
        }

        public string CadastrarFilme(Filme filme)
        {

            Filme bdFilme = _filmeRepositorio.BuscarFilmePorId(filme.Id);
            if (bdFilme == null)
            {
                bool result = _filmeRepositorio.CadastrarNovoFilme(filme);

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
                return "Filme já existe";
            }

        }

        public string DeletarFilme(int id)
        {

            Filme bdFilme = _filmeRepositorio.BuscarFilmePorId(id);
            if (bdFilme != null)
            {
                bool result = _filmeRepositorio.DeletarFilme(bdFilme.Id);

                if (result)
                {
                    return "Registro Excluído";
                }
                else
                {
                    return "Erro ao Excluir Registro";
                }

            }
            else
            {
                return "Filme já existe";
            }

        }

    }
}
