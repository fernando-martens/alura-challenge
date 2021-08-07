using Api.Challenge.Alura.Models;
using API.AluraFlix.Data.DTO;
using API.AluraFlix.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.AluraFlix.Business
{
    public class CategoriesBusiness
    {
        public static bool InsertBS(CategoryDTO categoryDTO)
        {

            Category category = new Category(categoryDTO);
            return CategoriesRepository.InsertRP(category);
        }

        public static List<CategoryDTO> ListBS()
        {
            List<Category> videos = CategoriesRepository.ListRP();
            return videos.Select((category) => new CategoryDTO(category)).ToList();
        }

        public static CategoryDTO GetOneBS(int id)
        {
            Category category = CategoriesRepository.GetOneRP(id);
            if (category == null)
                return null;
            return new CategoryDTO(category);
        }

        public static bool UpdateBS(CategoryDTO categoryDTO)
        {
            Category category = new Category(categoryDTO);
            return CategoriesRepository.UpdateRP(category);
        }

        public static bool DeleteBS(int id)
        {
            return CategoriesRepository.DeleteRP(id);
        }

        public static CategoryDTO001 GetVideosByCategoryBS(int id)
        {
            CategoryDTO categoryDTO = GetOneBS(id);
            if (categoryDTO == null)
                return null;

            CategoryDTO001 categoryDTO001 = new CategoryDTO001(categoryDTO);    
            categoryDTO001.Videos = VideosBusiness.GetByCategoryBS(id);
            return categoryDTO001;
        }
    }
}
