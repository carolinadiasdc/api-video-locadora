using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_video_locadora.Domain.Models
{
    public class Locacao
    {
        public Locacao(Cliente cliente, Filme filme, DateTime dataInicio, DateTime dataFim, int periodo, bool ativo)
        {


            Cliente = cliente;
            Filme = filme;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Periodo = periodo;
            Ativo = ativo;

        }


        public Cliente Cliente { get; set; }

        public Filme Filme { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int Periodo { get; set; }
      
        public bool Ativo { get; set; }
    }
}