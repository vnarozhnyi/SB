using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.Text;

namespace SeaBattle.Client.Services
{
    public class SeaBattleService
    {
        private HttpClient client;

        public SeaBattleService()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri("https://localhost:44386/");
        }

        public async Task<string> AddShip(string ship)
        {
            try
            {
                var response = await this.client.PostAsJsonAsync("api/ship/add", JsonConvert.SerializeObject(ship));
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public async Task<string> GetShoot(string shoot)
        {
            try
            {
                var response = await this.client.PostAsJsonAsync("api/ship/shoot", JsonConvert.SerializeObject(shoot));
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public async Task<string> GetRepair(string repair)
        {
            try
            {
                var response = await this.client.PostAsJsonAsync("api/ship/repair", JsonConvert.SerializeObject(repair));
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public async Task<string> InitMap(string field)
        {
            try
            {
                var response = await this.client.PostAsJsonAsync("api/ship/init", JsonConvert.SerializeObject(field));
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}