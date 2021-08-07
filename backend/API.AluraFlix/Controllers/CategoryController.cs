using Api.Challenge.Alura.Models;
using API.AluraFlix.Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.AluraFlix.Controllers
{
    [ApiController]
    [Route("categorias")]
    public class CategoryController : ControllerBase
    {

        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryDTO categoryDTO)
        {
            bool ok = CategoriesBusiness.InsertBS(categoryDTO);
            if (ok) return Ok();
            else return NotFound();
        }

        [HttpGet]
        public ActionResult GetCategories()
        {
            List<CategoryDTO> categories = CategoriesBusiness.ListBS();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory([FromRoute] int id)
        {

            CategoryDTO categoryDTO = CategoriesBusiness.GetOneBS(id);
            if (categoryDTO == null)
                return NotFound();

            return Ok(categoryDTO);
        }

        [HttpPatch]
        public IActionResult UpdateCategory([FromBody] CategoryDTO categoryDTO)
        {
            bool ok = CategoriesBusiness.UpdateBS(categoryDTO);
            if (ok) return Ok();
            else return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCategory(int id)
        {

            bool ok = CategoriesBusiness.DeleteBS(id);
            if (ok) return NoContent();
            else return NotFound();
        }


        [HttpGet]
        [Route("{id}/videos/")]
        public IActionResult GetVideosByCategory(int id)
        {
            CategoryDTO001 category = CategoriesBusiness.GetVideosByCategoryBS(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }
    }
}
