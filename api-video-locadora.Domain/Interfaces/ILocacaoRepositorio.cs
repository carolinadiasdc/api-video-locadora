using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_video_locadora.Domain.Interfaces
{
    public interface ILocacaoRepositorio
    {
        IEnumerable<Locacao> ListarTodasLocacoes();
        Locacao BuscarLocacaoPorId(long clienteCpf, int filmeId, DateTime dataIncio);
        bool CadastrarNovaLocacao(Locacao novaLocacao);
        bool DevolverFilme(Locacao devolucao);



    }
}