using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Travela.WebUI.Dtos;

namespace Travela.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ListCategory()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7092/api/Category");
            if (responseMessage.IsSuccessStatusCode) // IsSuccessStatusCode 200lü HTTP kodlarını döndürür, 200lü durum kodu genelde başarılı durumları gösterir
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Gelen veriyi string olarak oku
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData); //API den gelen verilerle Consume gelecek verilerin propertyleri birebir eşleşmek zorunda. Dtos adında bir klasör oluşturup bir class tanımlayıp tanımlanan class içeriğine jsondan gelen verilerle birebir aynı entity değerlerine ve yapısına sahip bir yapı kuruyoruz. Bunu da üst bardan Edit-Paste Special menüsünden yapabiliyoruz.
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //burada gönderilen içeriği, türkçe karaktere uygun formata getirtiyoruz.
            var responseMessage = await client.PostAsync("https://localhost:7092/api/Category", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ListCategory");
            }
            return View();
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7092/api/Category?id=" + id);
           return RedirectToAction("ListCategory");
        }

    }
}
