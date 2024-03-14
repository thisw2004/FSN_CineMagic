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
    
    
    public class ActorContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
    
        public ActorContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("default");
        }
    
        public DbSet<Actor>  Actors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        } 
    }
    
    public class OrderContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
    
        public OrderContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("default");
        }
    
        public DbSet<Order>  Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        } 
    }
    
    public class StaffContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
    
        public StaffContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("default");
        }
    
        public DbSet<Staff>  Staffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        } 
    }
    
    
    public class SeatContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
    
        public SeatContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("default");
        }
    
        public DbSet<Seat>  Seats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        } 
    }
    
    public class DiscountContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
    
        public DiscountContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("default");
        }
    
        public DbSet<Discounts>  Discounts { get; set; }

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