using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models.DAO
{
    public class personagensResumido
    {
        //tipo e nomesocial são nullables por conta dos retornos da api permitirem NULL.
        public int Id { get; set; }                           // PK obrigatória
        public string? Tipo { get; set; }
        public string Nome { get; set; } = null!;
        public string? NomeSocial { get; set; }

        // FK → Processo
        public int ProcessoId { get; set; }
        public Processo Processo { get; set; } = null!;
    }
}
