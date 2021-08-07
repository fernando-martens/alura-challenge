using MySql.Data.MySqlClient;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Challenge.Alura.Models
{
    public class Category
    {
        public Category(CategoryDTO categoryDTO)
        {
            Id = categoryDTO.Id;
            Titulo = categoryDTO.Titulo;
            Color = categoryDTO.Color;
        }

        public Category(MySqlDataReader rd)
        {
            Id = (int)rd["Id"];
            Titulo = (string)rd["Titulo"];
            Color = (string)rd["Color"];
        }

        [Key]
        [Required] 
        public int Id { get; set; }

        [Required]
        [MaxLength(180)]
        public String Titulo { get; set; }

        [Required]
        [MaxLength(20)]
        public String Color { get; set; }
    }
}
    