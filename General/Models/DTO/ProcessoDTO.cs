using General.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models.DTO
{
    public class ProcessoDTO
    {
        public string codProc { get; set; }
        public string codCnj { get; set; }
        public string descrFase { get; set; }
        public string tipoAutor { get; set; }
        public string tipoReu { get; set; }
        public string exibProc { get; set; }
        public string descServ { get; set; }
        public string nomeComarca { get; set; }
        public string nomeAutor { get; set; }
        public string nomeReu { get; set; }
        public List<personagensResumidoDTO> personagensResumido { get; set; }
        public int totalPersonagem { get; set; }
    }
}
