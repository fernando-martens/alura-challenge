using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Challenge.Alura.Models
{
    public class Category
    {
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
    