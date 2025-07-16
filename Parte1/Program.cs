using General.Models.DTO;
using General.Models.DTO.Request;
using General.Utilitarios;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class Program
{
    private static async Task Main()
    {
        try
        {

            //1 parte
            var processos = await RequisicaoTJRJ.ObterProcessosAsync();


            //obtendo os 10 primeiros processos sem ordenamento algum.
            processos = processos.Take(10).ToList();
            foreach (var processo in processos)
            {
                Console.WriteLine($"{processo.codProc} – {processo.tipoReu}");
            }




            Console.WriteLine(processos.Count);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
