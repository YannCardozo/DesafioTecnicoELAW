using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models.DTO.Request
{
    public class TJRJDTORequest
    {
        //model responsavel de ser o body no corpo da requisicao a api do TJRJ
        public TJRJDTORequest()
        {

        }

        public string aba { get; set; } = "nome";
        public int anoFinal { get; set; } = DateTime.Today.Year;
        public int anoInicial { get; set; } = DateTime.Today.Year - 1;
        public string? codCom { get; set; } = null;
        public string? codComp { get; set; } = null;
        public string comarca { get; set; } = "TODAS";
        public string competencia { get; set; } = "01";
        public string isPortal { get; set; } = "S";
        public int isPortalDeServicos { get; set; } = 1;
        public string nome { get; set; } = "Eduardo";
        public string origem { get; set; } = "1";
        public string pIsProcAtivos { get; set; } = "N";
        public string radio { get; set; } = "1";
        public string secao { get; set; } = "RJ";
        public string tipoConsulta { get; set; } = "publica";
        public string tipoSegundaInstancia { get; set; } = "1";
        public int totalProcessoPesquisa { get; set; } = 300;
        public bool validarSecao { get; set; } = true;
    }

}
