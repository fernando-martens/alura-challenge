using Api.Challenge.Alura.Models;
using API.AluraFlix.Data.DTO;
using AutoMapper;

namespace API.AluraFlix.Profiles
{
    public class VideoProfile : Profile
    {
        public VideoProfile()
        {
            CreateMap<VideoDTO, Video>();
            CreateMap<Video, VideoDTO>();
        }
      
    }
}
