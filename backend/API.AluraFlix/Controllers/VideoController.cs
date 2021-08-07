using API.AluraFlix.Business;
using API.AluraFlix.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Challenge.Alura.Controllers
{
    [ApiController]
    [Route("videos")]
    public class VideoController : ControllerBase 
    {
        public class DTOList
        {
            public string filter { get; set; }
            public int page { get; set; }
        }


        [HttpPost]
        public IActionResult AddVideo([FromBody] VideoDTO videoDTO)
        {
            bool ok = VideosBusiness.InsertBS(videoDTO);
            if (ok) return Ok();
            else return NotFound();
        }


        [HttpGet]
        public ActionResult GetVideos([FromQuery] DTOList dto) {
            List<VideoDTO> videos = VideosBusiness.ListBS(dto.filter, dto.page);
            return Ok(videos);
        }

        [HttpGet("{id}")]
        public IActionResult GetVideo([FromRoute] int id)
        {

            VideoDTO videoDTO = VideosBusiness.GetOneBS(id);
            if (videoDTO == null)
                return NotFound();

            return Ok(videoDTO);
        }


        [HttpPatch]
        public IActionResult UpdateVideo([FromBody] VideoDTO videoDTO)
        {
            bool ok = VideosBusiness.UpdateBS(videoDTO);
            if (ok) return Ok();
            else return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteVideo(int id)
        {

            bool ok = VideosBusiness.DeleteBS(id);
            if (ok) return NoContent();
            else return NotFound();
        }

    }
}
