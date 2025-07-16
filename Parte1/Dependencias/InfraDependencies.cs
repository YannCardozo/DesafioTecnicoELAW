using InfraData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parte1.Dependencias
{
    public static class InfraDependencies
    {
        public static ProcessoContext ObterProcessoContext()
        {
            try
            {
                const string conexao_banco = "Server=db23614.public.databaseasp.net;Database=db23614;User Id=db23614;Password=Pp4%-Zt3Hz7#;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
                var options = new DbContextOptionsBuilder<ProcessoContext>()
                                  .UseSqlServer(conexao_banco)
                                  .Options;

                return new ProcessoContext(options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Erro InfraDependencies ProcessoContext: {ex.Message}");
                throw;
            }

        }
        public static NovoProcessoContext ObterNovoProcessoContext()
        {
            try
            {
                const string conexao_banco_parte2 = "workstation id=ELAW_Parte2.mssql.somee.com;packet size=4096;user id=Chaons_SQLLogin_1;pwd=ffulsmgjr4;data source=ELAW_Parte2.mssql.somee.com;persist security info=False;initial catalog=ELAW_Parte2;TrustServerCertificate=True";
                var options = new DbContextOptionsBuilder<NovoProcessoContext>()
                      .UseSqlServer(conexao_banco_parte2)
                      .Options;

                return new NovoProcessoContext(options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Erro InfraDependencies NovoProcessoContext: {ex.Message}");
                throw;
            }

        }
    }
}
