using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_video_locadora.Domain.Models
{
    public class Filme
    {
        public Filme(int id, string nome, string genero, string status, bool ativo)
        {
            Id = id;
            Nome = nome;
            Genero = genero;
            Status = status;
            Ativo = ativo;
        }
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Genero { get; set; }

        public string Status { get; set; }

        public bool Ativo { get; set; }


    }
}