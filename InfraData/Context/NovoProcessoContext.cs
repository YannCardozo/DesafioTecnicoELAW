using General.Models.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraData.Context
{

    //Parte 2
    public class NovoProcessoContext : DbContext
    {
        string conexao_banco = "workstation id=ELAW_Parte2.mssql.somee.com;packet size=4096;user id=Chaons_SQLLogin_1;pwd=ffulsmgjr4;data source=ELAW_Parte2.mssql.somee.com;persist security info=False;initial catalog=ELAW_Parte2;TrustServerCertificate=True";

        public NovoProcessoContext()
        {

        }
        public NovoProcessoContext(DbContextOptions<NovoProcessoContext> options)
            : base(options)
        {
        }
        public DbSet<NovoProcesso> NovoProcesso { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(conexao_banco);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
