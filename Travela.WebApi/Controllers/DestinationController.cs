using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService  _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet]
        public IActionResult ListDestination()
        {
           var values= _destinationService.TGetListAll();
            return Ok(values);
        }
        [HttpGet("GetDestination")]
        public IActionResult GetDestination(int id)
        {
            var values = _destinationService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationService.TUpdate(destination);
            return Ok("Kategori güncelleme işlemi başarıyla tamamlandı.");
        }
        [HttpPost]
        public IActionResult CreateDestination(Destination destination)
        {
            _destinationService.TInsert(destination);
            return Ok("Kategori ekleme işlemi başarıyla tamamlandı.");
        }
        [HttpDelete]
        public IActionResult DeleteDestination(int id)
        {
            _destinationService.TDelete(id);
            return Ok("Kategori silme işlemi başarıyla tamamlandı.");
        }

    }
}
