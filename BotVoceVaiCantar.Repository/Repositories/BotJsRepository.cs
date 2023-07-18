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
        private readonly HttpOptions _url;

        public BotJsRepository(HttpClient httpClient, HttpOptions url)
        {
            _httpClient = httpClient;
            _url = url;
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
            HttpResponseMessage response = await _httpClient.PostAsync($"{_url}", content);

            // Lidar com a resposta, se necessário
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException("Informações incorretas");
            }
        }
    }
}
