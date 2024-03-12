using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CineMagicData.Models;

public class Contexts
{
    
    public class MovieContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
    
        public MovieContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("default");
        }
    
        public DbSet<Movie>  Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        } 
    }

    public class RoomContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
    
        public RoomContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("default");
        }
    
        public DbSet<Room>  Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        } 
    }
    
    public class RoomMovieContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public RoomMovieContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("default");
        }
        
        public DbSet<RoomMovie>  RoomMovie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        } 
    }
}