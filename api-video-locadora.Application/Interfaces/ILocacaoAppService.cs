using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_video_locadora.Application.Interfaces
{
    public interface ILocacaoAppService
    {
        IEnumerable<Locacao> ListarFilmesLocados();
        void LocarLocacao(int clienteId, int filmeId, int periodo);
        void DevolverLocacao(int clienteId, int filmeId);

    }
}
