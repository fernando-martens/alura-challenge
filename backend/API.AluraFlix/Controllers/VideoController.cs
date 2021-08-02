using Api.Challenge.Alura.Models;
using API.AluraFlix.Data;
using API.AluraFlix.Data.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Api.Challenge.Alura.Controllers
{
    [ApiController]
    [Route("videos")]
    public class VideoController : ControllerBase
    {

        private VideoContext _context;
        private IMapper _mapper;

        public VideoController(VideoContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddVideo([FromBody] VideoDTO videoDTO)
        {
            Video video = _mapper.Map<Video>(videoDTO);
            if (video.CategoriaId == null)
                video.CategoriaId = 1;

            _context.Videos.Add(video);
            _context.SaveChanges();
            return Ok();
        }


        [HttpGet]
        public ActionResult GetVideos([FromQuery] string search = null) {
            if (search != null)
            {
                List<Video> videos = _context.Videos.ToList<Video>();
                return Ok(videos.Where(videos => videos.Titulo == search));
            }
            return Ok(_context.Videos) ;
        }

        [HttpGet("{id}")]
        public IActionResult GetVideo([FromRoute] int id)
        {
            Video video = _context.Videos.Find(id);
            return Ok(video);
        }


        [HttpPatch]
        public IActionResult UpdateVideo([FromBody] VideoDTO videoDTO)
        {
            Video video = _context.Videos.Find(videoDTO.Id);
            if (video == null) return NotFound();

            _mapper.Map(videoDTO, video);
            _context.SaveChanges();
            return Ok(video);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteVideo(int id)
        {
            Video video = _context.Videos.Find(id);
            _context.Videos.Remove(video);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
