using Api.Challenge.Alura.Models;
using API.AluraFlix.Data.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
