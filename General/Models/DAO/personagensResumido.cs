using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models.DAO
{
    public class personagensResumido
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public string Nome { get; set; } = null!;
        public string? NomeSocial { get; set; }

        public int ProcessoId { get; set; }
        public Processo Processo { get; set; } = null!;
    }
}
