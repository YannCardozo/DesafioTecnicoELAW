using General.Models.DAO;
using General.Models.DTO;
using General.Models.DTO.Request;
using General.Models.DTO.Response;
using General.Utilitarios;
using InfraData.Context;
using Mensageria.Service;
using Microsoft.EntityFrameworkCore;
using Parte1.Dependencias;
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
        //instancia o ProcessoCONTEXT
        await using var db = InfraDependencies.ObterProcessoContext();
        try
        {
            //apagando registros para não popular milhões de registros sem necessidade.
            db.Processos.RemoveRange(db.Processos);
            await db.SaveChangesAsync();



            Console.WriteLine("Registros apagados com sucesso");
            //1 parte
            var processos = await RequisicaoTJRJ.ObterProcessosAsync();


            //obtendo os 10 primeiros processos sem ordenamento algum.
            processos = processos.Take(10).ToList();
            foreach (var processo in processos)
            {
                Console.WriteLine($"{processo.codProc} – {processo.tipoReu}");
            }





            List<Processo> processosParaCadastrar = processos
                .Select(dto => new Processo
                {
                    codProc = dto.codProc,
                    codCnj = dto.codCnj,
                    descrFase = dto.descrFase,
                    tipoAutor = dto.tipoAutor,
                    tipoReu = dto.tipoReu,
                    exibProc = dto.exibProc,
                    descServ = dto.descServ,
                    nomeComarca = dto.nomeComarca,
                    nomeAutor = dto.nomeAutor,
                    nomeReu = dto.nomeReu,
                    totalPersonagem = dto.totalPersonagem,

                    PersonagensResumidos = dto.personagensResumido
                    .Select(p => new personagensResumido
                    {
                        Tipo = p.tipo,
                        Nome = p.nome,
                        NomeSocial = p.nomeSocial
                    })
                    .ToList()
                })
                .ToList();

            await db.Processos.AddRangeAsync(processosParaCadastrar);
            await db.SaveChangesAsync();

            Console.WriteLine($"Foram Salvos {processos.Count} processos no banco.");



            //Formatando o Objeto PROCESSO do DESAFIO ( 6 bolinha do Parte 1 )
            List<NovoProcessoDTO> ListaNovoProcessoDTOMENSAGERIA = new();
            foreach(var registro in processos)
            {
                NovoProcessoDTO NovoProcessoDTOMENSAGERIA = new()
                {
                    NumeroProcesso = registro.codProc,
                    Origem = registro.origem,
                    Comarca_Regional = registro.nomeComarca,
                    Competencia = registro.competencia,
                    NomeParte = registro.personagensResumido[0].nome,
                    CriadoEm = DateTime.Now
                };

                ListaNovoProcessoDTOMENSAGERIA.Add(NovoProcessoDTOMENSAGERIA);
            }

            RabbitService.Publish(ListaNovoProcessoDTOMENSAGERIA);
            Console.WriteLine("Mensagem publicada na fila NOVOS_PROCESSOS.");


            Console.WriteLine($"Encerrando aplicação.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao executar o CONSOLE APP PARTE1: {ex.Message}");
        }
    }
}
