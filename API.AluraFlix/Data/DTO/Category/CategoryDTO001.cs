using API.AluraFlix.Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Challenge.Alura.Models
{
    public class CategoryDTO001 : CategoryDTO
    {
        public CategoryDTO001(CategoryDTO categoryDTO)
        {
            Id = categoryDTO.Id;
            Titulo = categoryDTO.Titulo;
            Color = categoryDTO.Color;
        }

        public List<VideoDTO> Videos { get; set; }

    }
}
    