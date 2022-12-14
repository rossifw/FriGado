using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FriGado.App.Models
{
    public class CompraGadoItem
    {
        public int Id { get; set; }
        public CompraGado CompraGado { get; set; }
        public Animal Animal { get; set; }
        public int Quantidade { get; set; }


        private static readonly string _url = $"{Config.APIUrl}/compraGadoItem";
        private static readonly HttpClient _client = GetHttpClient();

        public static HttpClient GetHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Config.BearerToken);
            return httpClient;
        }
        public static async Task<CompraGadoItem> Get(int id)
        {
            var response = await _client.GetStringAsync($"{_url}/{id}");
            var CompraGadoItem = JsonConvert.DeserializeObject<CompraGadoItem>(response);
            return CompraGadoItem;
        }

        public async static Task<List<CompraGadoItem>> GetTodos()
        {
            var response = await _client.GetStringAsync(_url);
            return JsonConvert.DeserializeObject<List<CompraGadoItem>>(response);
        }

        public static async Task<int> Adicionar(CompraGadoItem CompraGadoItem)
        {
            var content = new StringContent(JsonConvert.SerializeObject(CompraGadoItem), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_url, content);
            return Convert.ToInt32(await response.Content.ReadAsStringAsync());
        }

        public static async Task<int> Atualizar(CompraGadoItem CompraGadoItem)
        {
            var content = new StringContent(JsonConvert.SerializeObject(CompraGadoItem), Encoding.UTF8, "application/json");
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
