using api_video_locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_video_locadora.Dados.Repositorio
{
    public class LocacaoRepositorio
    {
        private List<Locacao> locacoes;


        public LocacaoRepositorio()
        {
            locacoes = new List<Locacao>()
            {
            };
        }
    }
}
