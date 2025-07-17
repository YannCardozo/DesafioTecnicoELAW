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
        const string recaptchaToken = "03AFcWeA7tOzHpc_VxsJBRXoALM184PtfTZj74WivZEklvRprsBtC0BuUfP-y47S8Lw2vejmWjGDZM-nu3rr7OofrBynf_geG-4sSRjZRP-Dvc-QQPkpnSuWmRkS47FTp5vJlxnWltd-_Ja_ZhLCrwTmySoq94Z3M9qVQcR1T_yAj54jnZhuon9bpJwudQOO9otGuFyzytOE6nB8gSjXe7pejjMVArS4qytkhutxF3LNy2V3Fvj-tGcCp06IbB9IPOEBUKDUh1AwRITeDCkDGkjEUoFOqf84lbPPLDgkxl-sLDyxIs1TnaXTvmHfvKM3jVz3isQyY9kvGwNxbrdq_xopww6NFmIi9lTPifDzFSX54Wcg3isVzVq4S5pWr61bROLCSPSyWVQqRoyu-kwrybHg8k4mb2_tg0eNPfIWry8OVYuL7qSce_IwIQsX4rhi-WUDk_l--hrszla1-I_fyun6QElIPbJNX5apsxJswsz1yopWQljdguykjiykT-4fGaXfhqShbbLZRhF-U9P7ViKSakj5NgpFnE5vap-QYBT4lnnpROD_ewdY97BcdUdrIAJ9hLjnN4Ccg7Ccmo9QtHyDzPw2V1uOwYJRhZr6Wmp0vHj0eHxlFSyescc4O1fJcgJByPnNbad9-m-fG0r17anBQ3MREbsCi1WojHdu3OfbMAlLX9niZTZzvZvLybgWAOARrRNPb0MauKLxbXSHlshYpG2l023k7Mq4yMbN3GjdnyJV57m9rzNw_uyBCN_PUMvXKD_RcUY5_0mMjeyx2ipcFuBUMT8lfUi9CblEKt0XTF9sG3jZSULA74L83BYC_VeZTbe5GUBE-Ro4fy48TV_zt72UgpUW474KWhvZ-Ot_vZ8WivzTtGrQopMLKqVXbo0g85xDsG-5WqEgwnMGUeadBSpjh5bj037qbW8DboSj_DOBM1N2RPjHt_usbcZ4fpf7DEW-r9bhGnbeRhPkO0wtypvgdO9wvJXLuh1DGH-IVZCUA8PplYaqGhiegyjo8FEkL9nxZQvfNZ";

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
