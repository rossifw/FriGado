using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FriGado.App.Models
{
    public class CompraGado
    {
        public int Id { get; set; }
        public Pecuarista Pecuarista { get; set; }
        public DateTime DataEntrega { get; set; }


        private static readonly string _url = $"{Config.APIUrl}/compraGado";
        private static readonly HttpClient _client = new HttpClient();

        public static async Task<CompraGado> Get(int id)
        {
            var response = await _client.GetStringAsync($"{_url}/{id}");
            var compraGado = JsonConvert.DeserializeObject<CompraGado>(response);
            return compraGado;
        }

        public async static Task<List<CompraGado>> GetTodos()
        {
            var response = await _client.GetStringAsync(_url);
            return JsonConvert.DeserializeObject<List<CompraGado>>(response);
        }

        public static async Task<int> Adicionar(CompraGado compraGado)
        {
            var content = new StringContent(JsonConvert.SerializeObject(compraGado), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_url, content);
            return Convert.ToInt32(await response.Content.ReadAsStringAsync());
        }

        public static async Task<int> Atualizar(CompraGado compraGado)
        {
            var content = new StringContent(JsonConvert.SerializeObject(compraGado), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(_url, content);
            return Convert.ToInt32(await response.Content.ReadAsStringAsync());
        }

        public static async Task<int> Remover(int id)
        {
            var response = await _client.DeleteAsync($"{_url}/{id}");
            return Convert.ToInt32(await response.Content.ReadAsStringAsync());
        }
    }
}
