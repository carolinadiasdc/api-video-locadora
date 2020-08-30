using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_video_locadora.Application.Interfaces
{
    public interface ILocacaoAppService
    {
        IEnumerable<Locacao> ListarTodasLocacoes();
        Locacao BuscarLocacaoPorId(long clienteCpf, int filmeId, DateTime dataIncio);
        string CadastrarNovaLocacao(long clienteCpf, int filmeId, int periodo);
        string DevolverFilme(long clienteCpf, int filmeId, DateTime dataLocacao);

    }
}
