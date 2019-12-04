using System.Net.Http;

namespace SeaBattle.Client.Hubs
{
    public interface IHttpClientFactory
    {
        HttpClient CreateClient(string name);
    }
}