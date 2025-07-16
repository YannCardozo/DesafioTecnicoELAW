using General.Models.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraData.Context
{
    public class ProcessoContext : DbContext
    {
        //string conexao_banco = "Server=db22815.databaseasp.net;Database=db22815;UserId=db22815;Password=nP#36yS+e%7M;Encrypt=False;MultipleActiveResultSets=True;";
        public ProcessoContext(DbContextOptions<ProcessoContext> options)
           : base(options)
        {
        }

        public DbSet<Processo> Processos { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
