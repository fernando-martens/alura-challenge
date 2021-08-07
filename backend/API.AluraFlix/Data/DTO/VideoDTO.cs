using Api.Challenge.Alura.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.AluraFlix.Data.DTO
{
    public class VideoDTO
    {
        public VideoDTO(Video video)
        {
            Id = video.Id;
            Titulo = video.Titulo;
            CategoriaId = video.CategoriaId;
            Descricao = video.Descricao;
            Url = video.Url;
        }

        public VideoDTO() { }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(180)]
        public String Titulo { get; set; }

        public int? CategoriaId { get; set; }

        [Required]
        [MaxLength(180)]
        public String Descricao { get; set; }

        [Required]
        public String Url { get; set; }
    }
}

