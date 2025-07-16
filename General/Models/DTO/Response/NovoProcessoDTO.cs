using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models.DTO.Response
{
    public class NovoProcessoDTO
    {
        public string NumeroProcesso { get; set; }
        public string Origem { get; set; }
        public string Comarca_Regional { get; set; }
        public string Competencia { get; set; }
        public string NomeParte { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
