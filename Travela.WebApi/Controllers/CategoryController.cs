using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult ListCategory()
        {
            var values = _categoryService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryService.TInsert(category);
            return Ok("Kategori ekleme işlemi başarıyla tamamlandı.");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Kategori silme işlemi başarıyla tamamlandı.");
        }
        [HttpGet("GetCategory")] //Aynı attribute u kullanabilmek için [HttpGet("GetCategory")] kullanılır. Burada get attributeunu bu metot için işaretliyoruz.
        public IActionResult GetCategory(int id)
        {
            var values = _categoryService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return Ok("Kategori güncelleme işlemi başarıyla tamamlandı.");
        } 
    }
}
