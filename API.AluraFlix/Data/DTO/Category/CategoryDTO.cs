using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Challenge.Alura.Models
{
    public class CategoryDTO
    {
        public CategoryDTO(Category category)
        {
            Id = category.Id;
            Titulo = category.Titulo;
            Color = category.Color;
        }

        public CategoryDTO() { }

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
    