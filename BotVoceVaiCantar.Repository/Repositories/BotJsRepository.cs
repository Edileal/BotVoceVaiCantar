using BotVoceVaiCantar.Domain.Contracts;
using BotVoceVaiCantar.Domain.Interfaces;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace BotVoceVaiCantar.Repository.Repositories
{
    public class BotJsRepository : IBotJsRepository
    {
        private readonly HttpClient _httpClient;
        private readonly HttpEnviaData _enviaData;

        public BotJsRepository(HttpClient httpClient, HttpEnviaData enviaData)
        {
            _httpClient = httpClient;
            _enviaData = enviaData;
        }

        public async Task PostAsJsonNoContentAsync(LembreteRequest request)
        {
            string json = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            // Chamada HTTP POST para a segunda API
            HttpResponseMessage response = await _httpClient.PostAsync($"{_enviaData}", content);

            // Lidar com a resposta, se necessário
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException("Informações incorretas");
            }
        }
    }
}
