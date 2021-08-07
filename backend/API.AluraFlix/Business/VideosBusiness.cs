using Api.Challenge.Alura.Models;
using API.AluraFlix.Data.DTO;
using API.AluraFlix.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.AluraFlix.Business
{
    public class VideosBusiness
    {
        public static bool InsertBS(VideoDTO videoDTO)
        {

            Video video = new Video(videoDTO);
            if (video.CategoriaId == null)
                video.CategoriaId = 1;
            return VideosRepository.InsertRP(video);
        }

        public static List<VideoDTO> ListBS(string filter, int page)
        {
            List<Video> videos = VideosRepository.ListRP(filter, page);
            return videos.Select((video) => new VideoDTO(video)).ToList();
        }
        public static List<VideoDTO> ListPaginationBS(int page)
        {
            List<Video> videos = VideosRepository.ListPaginationRP(page);
            return videos.Select((video) => new VideoDTO(video)).ToList();
        }

        public static VideoDTO GetOneBS(int id)
        {
            Video video = VideosRepository.GetOneRP(id);
            if (video == null)
                return null;
            return new VideoDTO(video);
        }

        public static bool UpdateBS(VideoDTO videoDTO)
        {
            Video video = new Video(videoDTO);
            if (video.CategoriaId == null)
                video.CategoriaId = 1;
            return VideosRepository.UpdateRP(video);
        }

        public static bool DeleteBS(int id)
        {
            return VideosRepository.DeleteRP(id);
        }

        public static List<VideoDTO> GetByCategoryBS(int id)
        {
            List<Video> videos = VideosRepository.ListByCategoryRP(id);
            return videos.Select((video) => new VideoDTO(video)).ToList();
        }
    }
}
