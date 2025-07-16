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
        string conexao_banco = "Server=db23614.public.databaseasp.net; Database=db23614; User Id=db23614; Password=Pp4%-Zt3Hz7#; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public ProcessoContext()
        {
        
        }
        public ProcessoContext(DbContextOptions<ProcessoContext> options)
           : base(options)
        {
        }
        public DbSet<Processo> Processos { get; set; }
        public DbSet<personagensResumido> PersonagensResumidos { get; set; }

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
