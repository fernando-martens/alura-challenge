using Api.Challenge.Alura.Models;
using AutoMapper;

namespace API.AluraFlix.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
        }
      
    }
}
