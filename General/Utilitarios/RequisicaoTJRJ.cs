using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using General.Models.DTO;
using General.Models.DTO.Request;

namespace General.Utilitarios;

public static class RequisicaoTJRJ
{
    public static async Task<List<ProcessoDTO>> ObterProcessosAsync()
    {
        const string recaptchaToken = "03AFcWeA6foKbNpLgmkPlscM8FCb5qmh1qt3lKBAp2CmiM3C2Bg7Yfr7-4pVmce9dhszzPvlXi6St1zkd5hyO6xW3gk8HStIwJrr8nJOTyDOYCha3309vkEN_B57FN5w8FRX4l7HCr98TtkoSQpJYaYcFdirWywW8Bgl_Xd3KWdO-ujbBJE9WFIlwvFmS9MW_im6yfR8AT-CmbrlBf9H7u6fnC9bZECVmQA5WMm2AQQIQTtP5OOQnwY55x4GZhH381gv56iA3UufY00MBlCwpIt8DulwXfnxRtZ-v9aFdvWcsee1gU2WFn2n9hJFd_C4oEN9wevTrxD7lqr0EdSLb9SyQpdaXD7oCeL8uJp2YCPnvCnaw7XNCiKYNHNgNVPnFlz_GBgi2J-DiZbaKYD_0wmgtyeLTw8JwHyRygkELQUgRsKnqI37Ojy86gvcklJ60A9BEay9cbvbu4LS-4eEZicB6JSYQQavjByvJyCG3Tjo7pXl7fBOrHS0npceDSIneuP-MC1zRCCMYUpVXXh8kUHRbgHd48mhVvHNx_5Kbc_M1x1iehNoyjS9Ti2ISMHU14FBU5MVRbvJPdsSIRucBqiE42zYoYidq65zibfvZhBfenZ_5wlF5L06TwW1u7GL9gfgYLXJDzKEbM5l01fza9ycVh0E8duJgwe_fZp5BDGyMQZ_JKhxrEb2yhmmF6OqKdzeXoI5ji2Zp7sayRIPWMxRyrmvs6oFUFhRK14vynVsLydfd01Jf23A8N-3drOolpNhpZTF6WoNnlcB4BnaDrv-1LyxBoCHXtMEYWyQb7i_SHfuFvNsC6oUdmUi6L6YRec1WtTfoMV8PSeiqAswzrxgcJDHntIgf35x0cv5a2h4CqBnNc1CzjmVIwMXpitmzOlNqIZLOTnKd90aRPegtkHWEAVMtqu5O1NQwKZ8y5tnlcRlZu3mS5DR-n3vMF9KrgE3TY5lIbsHCxFcVHkbBf3Q91NddreVep0qoOQJDAVEojcW5F0y46MtGcC23OfuDMvnwaSa4Qed_5";

        try
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri("https://www3.tjrj.jus.br/consultaprocessual/api/processos/por-nome-parte"),
                Timeout = TimeSpan.FromMinutes(1)
            };

            client.DefaultRequestHeaders.TryAddWithoutValidation("recaptcha-token", recaptchaToken);
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/138.0.0.0 Mobile Safari/537.36");

            var body = new TJRJDTORequest
            {
                aba = "nome",
                anoFinal = 2025,
                anoInicial = 2024,
                codCom = null,
                codComp = null,
                comarca = "TODAS",
                competencia = "01",
                isPortal = "S",
                isPortalDeServicos = 1,
                nome = "Eduardo",
                origem = "1",
                pIsProcAtivos = "N",
                radio = "1",
                secao = "RJ",
                tipoConsulta = "publica",
                tipoSegundaInstancia = "1",
                totalProcessoPesquisa = 300,
                validarSecao = true
            };

            var jsonBody = JsonSerializer.Serialize(body);
            using var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");


            var resposta = await client.PostAsync("", content);
            resposta.EnsureSuccessStatusCode();

            var jsonResposta = await resposta.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var lista = JsonSerializer.Deserialize<List<ProcessoDTO>>(jsonResposta, options);

            return lista;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            throw;
        }
    }
}
