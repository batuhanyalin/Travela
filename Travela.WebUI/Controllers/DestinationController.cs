using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Travela.BusinessLayer.Abstract;
using Travela.WebUI.Dtos;

namespace Travela.WebUI.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DestinationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }
        [HttpGet]
        public async Task<IActionResult> ListDestination()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7092/api/Destination");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDestinationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateDestination()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDestination(CreateDestinationDto createDestinationDto, IFormFile Image)
        {
            if (Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(resource, "wwwroot/images", imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                createDestinationDto.ImageUrl = $"/images/{imageName}";
            }
            else if (createDestinationDto.ImageUrl == null)
            {
                createDestinationDto.ImageUrl = $"/images/no-image.jpg";
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDestinationDto);
            StringContent stringContext = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7092/api/Destination", stringContext);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ListDestination", "Destination");
            }
            return View();
        }
        public async Task<IActionResult> DeleteDestination(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7092/api/Destination?id=" + id);
            return RedirectToAction("ListDestination", "Destination");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDestination(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7092/api/Destination/GetDestination?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<UpdateDestinationDto>(jsonData);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDestination(UpdateDestinationDto updateDestinationDto,IFormFile Image)
        {
            if (Image != null)
            {
                var resource=Directory.GetCurrentDirectory();
                var extension= Path.GetExtension(Image.FileName);
                var imageName=Guid.NewGuid()+ extension;
                var saveLocation =Path.Combine(resource,"wwwroot/images",imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                updateDestinationDto.ImageUrl = $"/images/{imageName}";
            }
            else if (updateDestinationDto.ImageUrl == null)
            {
                updateDestinationDto.ImageUrl = $"/images/no-image.jpg";
            }
            var client= _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(updateDestinationDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7092/api/Destination", stringContent);
            return RedirectToAction("ListDestination");
        }
    }
}
