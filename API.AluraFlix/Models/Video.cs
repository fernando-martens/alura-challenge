using API.AluraFlix.Data.DTO;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Challenge.Alura.Models
{
    public class Video
    {
        public Video(MySqlDataReader rd)
        {
            Id = (int)rd["Id"];
            Titulo = (string)rd["Titulo"];
            CategoriaId = (int)rd["CategoriaId"];
            Descricao = (string)rd["Descricao"];
            Url = (string)rd["Url"];
        }

        public Video(VideoDTO videoDTO)
        {
            Id = videoDTO.Id;
            Titulo = videoDTO.Titulo;
            CategoriaId = videoDTO.CategoriaId;
            Descricao = videoDTO.Descricao;
            Url = videoDTO.Url;
        }

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
    