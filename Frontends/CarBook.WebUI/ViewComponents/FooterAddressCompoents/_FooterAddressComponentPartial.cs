﻿using CarBook_1.Dto.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook_1.WebUI.ViewComponents.FooterAddressCompoents
{
    public class _FooterAddressComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterAddressComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.GetAsync("https://localhost:7174/api/FooterAddresses");
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
