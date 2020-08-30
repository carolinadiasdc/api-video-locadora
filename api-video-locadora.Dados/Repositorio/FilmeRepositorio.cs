using api_video_locadora.Domain.Interfaces;
using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace api_video_locadora.Dados.Repositorio
{
    public class FilmeRepositorio: IFilmeRepositorio
    {
        private List<Filme> filmes;

        public FilmeRepositorio()
        {

            filmes = new List<Filme>
        {
            new Filme (1,"O Poderoso Chefão", "Drama","Disponível", true),
            new Filme (2, "Star Wars IV", "Ficção", "Disponível", true),
            new Filme (3, "Branca de Neve"," Infantil", "Disponível", true),
            new Filme (4, "Clube da Luta","Ação", "Disponível", true)

        };

        }

        public IEnumerable<Filme> ListarTodosFilmes()
        {
            return filmes;

        }
        public Filme BuscarFilmePorId(int id)
        {
            return filmes.Where(filme => filme.Id == id && filme.Ativo == true).FirstOrDefault();

        }

        public bool CadastrarNovoFilme(Filme novoFilme)
        {

            Filme filmeRepetido = BuscarFilmePorId(novoFilme.Id);
            if (filmeRepetido == null)
            {

                filmes.Add(novoFilme);
                return true;
            }
            else
            {
                return false;

            }

        }

        public bool DeletarFilme(int id)
        {
            Filme filme = BuscarFilmePorId(id);

            if (filme != null && filme.Ativo == true)
            {
                filmes.Remove(filme);
                filme.Ativo = false;
                filmes.Add(filme);

                return true;
            }
           
            else
            {
                return false;
            }

        }

        public bool AtualizarStatusFilme (int id, string status)
        {
            Filme filme = BuscarFilmePorId(id);

            if (filme != null && filme.Ativo == true)
            {
                filmes.Remove(filme);
                filme.Status = status;
                filmes.Add(filme);

                return true;
            }

            else
            {
                return false;
            }

        }

    }

}

