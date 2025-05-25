using CarBook_1.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); //İstekte bulunabilmek için istemci oluşturmak
            var responseMesage = await client.GetAsync("https://localhost:7174/api/Abouts"); //İstekte bulunulacak URL buraya yazılıyor. Listeleme işlemi için gerçekleştirildi. 
            if (responseMesage.IsSuccessStatusCode)
            {
                //İki yüzlü durum kodlarını temsil eder. (İki yüzlü durum kodları: API işlemlerinde durum kodlarını kontrol eder. Örn: 200, 201 vb.)

                //Eğer kod çalışırsa
                var jsonData = await responseMesage.Content.ReadAsStringAsync(); //API'den gelen veriyi string formatta okur

                //Okuduktan sonra:
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData); //Aldığı datayı karşılaştırmak için kullanılıyor. Burada ayrı bir Dto projesi ekledik.

                return View(values);
            }
            return View();
        }
    }
}
