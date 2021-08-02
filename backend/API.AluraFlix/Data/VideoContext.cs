using Api.Challenge.Alura.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.AluraFlix.Data
{
    public class VideoContext : DbContext
    {
        
        public VideoContext(DbContextOptions<VideoContext> opt) : base(opt)
        {
        }

        public virtual DbSet<Video> Videos { get; set; }

    }
}
