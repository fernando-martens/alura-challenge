using Api.Challenge.Alura.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.AluraFlix.Data
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> opt) : base(opt)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
    }
}
