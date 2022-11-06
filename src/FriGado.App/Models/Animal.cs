using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FriGado.App.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        private static readonly string _url = "https://localhost:44345/api/animal";
        private static readonly HttpClient _client = new HttpClient();

        public static async Task<Animal> Get(int id)
        {
            var response = await _client.GetStringAsync($"{_url}/{id}");
            var animal = JsonConvert.DeserializeObject<Animal>(response);
            return animal;
        }

        public async static Task<List<Animal>> GetTodos()
        {
            var response = await _client.GetStringAsync(_url);
            return JsonConvert.DeserializeObject<List<Animal>>(response);
        }

        public static async Task<int> Adicionar(Animal animal)
        {
            var content = new StringContent(JsonConvert.SerializeObject(animal), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_url, content);
            return Convert.ToInt32(await response.Content.ReadAsStringAsync());
        }

        public static async Task<int> Atualizar(Animal animal)
        {
            var content = new StringContent(JsonConvert.SerializeObject(animal), Encoding.UTF8, "application/json");
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
