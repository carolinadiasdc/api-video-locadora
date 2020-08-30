using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_video_locadora.Models
{
    public class Devolucao
    {
        public long clienteCpf { get; set; }
        public int filmeId { get; set; }
        public DateTime dataLocacao { get; set; }

    }
}
