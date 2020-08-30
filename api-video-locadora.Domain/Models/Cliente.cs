using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_video_locadora.Domain.Models
{
    public class Cliente
    {
        public Cliente(long cpf, string nome, string fone, string email, bool ativo)
        {
            Cpf = cpf;
            Nome = nome;
            Fone = fone;
            Email = email;
            Ativo = ativo;
        }



        public long Cpf { get; set; }
       
        public string Nome { get; set; }
        
        public string Fone { get; set; }
        
        public string Email { get; set; }
        
        public bool Ativo { get; set; }

    }
}