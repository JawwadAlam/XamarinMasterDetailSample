using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using MasterDetail.Models;

namespace MasterDetail.Services
{
    public class GhibliService
    {
        HttpClient client;
        IEnumerable<Film> items;

        public GhibliService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.GhibliBackendUrl}/");

            items = new List<Film>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<Film>> GetFilmsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"films");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Film>>(json));
            }

            return items;
        }

        public async Task<Film> GetFilmAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/item/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Film>(json));
            }

            return null;
        }
    }
}
