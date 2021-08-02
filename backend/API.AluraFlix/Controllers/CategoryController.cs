using Api.Challenge.Alura.Models;
using API.AluraFlix.Data;
using API.AluraFlix.Data.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.AluraFlix.Controllers
{
    [ApiController]
    [Route("categorias")]
    public class CategoryController : ControllerBase
    {
        private CategoryContext _context;
        private VideoContext _videoContext;
        private IMapper _mapper;

        public CategoryController(CategoryContext context, VideoContext videocontext,  IMapper mapper)
        {
            _context = context;
            _videoContext = videocontext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<Category>(categoryDTO);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetCategories() {
            return Ok(_context.Categories);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCategory(int id) {
            Category category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPatch]
        public IActionResult UpdateCategory([FromBody] CategoryDTO categoryDTO)
        {
            Category category = _context.Categories.Find(categoryDTO.Id);
            if (category == null) return NotFound();

            _mapper.Map(categoryDTO, category);
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            Category category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        [Route("{id}/videos/")]
        public IActionResult GetVideosByCategory(int id) {
            List<Video> videos = _videoContext.Videos.ToList<Video>();
            return Ok(videos.Where(videos => videos.CategoriaId == id));
        }
    }
}
