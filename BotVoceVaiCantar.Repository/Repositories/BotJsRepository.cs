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
        private readonly HttpOptions _enviaData;

        public BotJsRepository(HttpClient httpClient, HttpOptions enviaData)
        {
            _httpClient = httpClient;
            _enviaData = enviaData;
        }

        public async Task PostAsJsonNoContentAsync(string uri, object objeto)
        {
            var response = await _httpClient.PostAsJsonAsync(uri, objeto);
        }

        public async Task PostAsJsonNoContentAsync(string number, string data)
        {
            var objetoParaEnviar = new
            {
                numero = number,
                msg = data,
            };
            string json = JsonConvert.SerializeObject(objetoParaEnviar);
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
