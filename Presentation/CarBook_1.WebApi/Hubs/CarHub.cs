using Microsoft.AspNetCore.SignalR;

namespace CarBook_1.WebApi.Hubs
{
    public class CarHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.GetAsync("https://localhost:7174/api/Statistics/GetCarCount");
            var value = await responseMesage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCarCount",value);
        }

    }
}
