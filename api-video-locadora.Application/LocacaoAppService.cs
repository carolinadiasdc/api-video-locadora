using api_video_locadora.Application.Interfaces;
using api_video_locadora.Domain.Interfaces;
using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_video_locadora.Application
{
    public class LocacaoAppService : ILocacaoAppService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IFilmeRepositorio _filmeRepositorio;
        private readonly ILocacaoRepositorio _locacaoRepositorio;

        public LocacaoAppService(IClienteRepositorio clienteRepositorio, IFilmeRepositorio filmeRepositorio, ILocacaoRepositorio locacaoRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _filmeRepositorio = filmeRepositorio;
            _locacaoRepositorio = locacaoRepositorio;

        }

        public IEnumerable<Locacao> ListarTodasLocacoes()
        {
            return _locacaoRepositorio.ListarTodasLocacoes();

        }
        public Locacao BuscarLocacaoPorId(long clienteCpf, int filmeId, DateTime dataIncio)

        {
            return _locacaoRepositorio.BuscarLocacaoPorId(clienteCpf, filmeId, dataIncio);

        }

        public string CadastrarNovaLocacao(long clienteCpf, int filmeId, int periodo)
        {
            DateTime hoje = DateTime.Now;


            Filme filme = _filmeRepositorio.BuscarFilmePorId(filmeId);
            if (filme != null && filme.Status == "Disponível")
            {
                Cliente cliente = _clienteRepositorio.BuscarClientePorId(clienteCpf);
                if (cliente != null)
                {

                    Locacao locacao = new Locacao(cliente, filme, hoje, null, periodo, true, 0);

                    if (_locacaoRepositorio.CadastrarNovaLocacao(locacao))
                    {
                        _filmeRepositorio.AtualizarStatusFilme(filme.Id, "Indisponível");

                        return "Filme locado com sucesso";
                    }
                    else
                    {
                        return $"Não foi possível locar o filme: {filme.Nome} ";

                    }
                }
                else
                {
                    return $"Não foi possível locar o filme: {filme.Nome}, cliente não existe";
                }

            }
            else
            {
                return "Filme indisponível.";
            }

        }

        public string DevolverFilme(long clienteCpf, int filmeId, DateTime dataLocacao)
        {
            Locacao locacao = _locacaoRepositorio.BuscarLocacaoPorId(clienteCpf, filmeId, dataLocacao);

            if (locacao != null && locacao.DataFim == null)
            {
                locacao.DataFim = DateTime.Now;

                if (_locacaoRepositorio.DevolverFilme(locacao))
                {
                    _filmeRepositorio.AtualizarStatusFilme(locacao.Filme.Id, "Disponível");

                    return "Devolvido com sucesso";
                }
                else
                {
                    return "Não foi possível devolver o filme";
                }

            }
            else
            {
                return "Locação Inexistente ou já devolvida";
            }

        }

    }
}
