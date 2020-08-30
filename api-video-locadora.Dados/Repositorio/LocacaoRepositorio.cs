using api_video_locadora.Domain.Interfaces;
using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace api_video_locadora.Dados.Repositorio
{
    public class LocacaoRepositorio: ILocacaoRepositorio
    {
        private List<Locacao> locacoes;


        public LocacaoRepositorio()
        {
            locacoes = new List<Locacao>()
            {
            };
        }
     

        public IEnumerable<Locacao> ListarTodasLocacoes()
        {
            foreach (var locacao in locacoes)
            {
                int diasAtraso = CalculaAtraso(locacao);


                if (diasAtraso > 0)
                {
                    locacoes.Remove(locacao);
                    locacao.DiasAtraso = diasAtraso;
                    locacoes.Add(locacao);

                }

            }

            return locacoes;
        }
        public Locacao BuscarLocacaoPorId(long clienteCpf, int filmeId, DateTime dataIncio)

        {
            Locacao locacao = locacoes.Where(locacao => locacao.Cliente.Cpf == clienteCpf
            && locacao.Filme.Id == filmeId
            && locacao.Ativo == true
            && locacao.DataInicio == dataIncio)
            .FirstOrDefault();

            if (locacao != null)
            {
                int diasAtraso = CalculaAtraso(locacao);

                if (diasAtraso > 0)
                {
                    locacoes.Remove(locacao);
                    locacao.DiasAtraso = diasAtraso;
                    locacoes.Add(locacao);

                }

            }

            return locacao;

        }

        public bool CadastrarNovaLocacao(Locacao novaLocacao)
        {

            Locacao locacaoRepetida = BuscarLocacaoPorId(novaLocacao.Cliente.Cpf, novaLocacao.Filme.Id, novaLocacao.DataInicio);

            if (locacaoRepetida == null || locacaoRepetida.Ativo == false)
            {

                locacoes.Add(novaLocacao);
                return true;
            }
            else
            {
                return false;

            }

        }

        public bool DevolverFilme(Locacao devolucao)
        {
            Locacao locacao = BuscarLocacaoPorId(devolucao.Cliente.Cpf, devolucao.Filme.Id, devolucao.DataInicio);

            if (locacao != null && locacao.Ativo == true)
            {
                int diasAtraso = CalculaAtraso(locacao);
                locacoes.Remove(locacao);

                if (diasAtraso > 0)
                {
                    locacao.DiasAtraso = diasAtraso;
                }

                locacao.DataFim = DateTime.Now;


                locacoes.Add(locacao);

                return true;
            }

            else
            {
                return false;
            }

        }
        private int CalculaAtraso(Locacao locacao)
        {
            DateTime inicio = locacao.DataInicio;
            return (DateTime.Now - inicio.AddDays(locacao.Periodo)).Days;


        }
    }
}
