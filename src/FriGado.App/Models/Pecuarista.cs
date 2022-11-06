using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace FriGado.App.Models
{
    public class Pecuarista
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        private static readonly string _url = $"{Config.APIUrl}/pecuarista";
        private static readonly HttpClient _client = new HttpClient();

        public static async Task<Pecuarista> Get(int id)
        {
            var response = await _client.GetStringAsync($"{_url}/{id}");
            var pecuarista = JsonConvert.DeserializeObject<Pecuarista>(response);
            return pecuarista;
        }

        public async static Task<List<Pecuarista>> GetTodos()
        {
            var response = await _client.GetStringAsync(_url);
            return JsonConvert.DeserializeObject<List<Pecuarista>>(response);
        }

        public static async Task<int> Adicionar(Pecuarista pecuarista)
        {
            var content = new StringContent(JsonConvert.SerializeObject(pecuarista), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_url, content);
            return Convert.ToInt32(await response.Content.ReadAsStringAsync());
        }

        public static async Task<int> Atualizar(Pecuarista pecuarista)
        {
            var content = new StringContent(JsonConvert.SerializeObject(pecuarista), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(_url, content);
            return Convert.ToInt32(await response.Content.ReadAsStringAsync());
        }

        public static async Task<int> Remover(int id)
        {
            var response = await _client.DeleteAsync($"{_url}/{id}");
            return Convert.ToInt32(await response.Content.ReadAsStringAsync());
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
