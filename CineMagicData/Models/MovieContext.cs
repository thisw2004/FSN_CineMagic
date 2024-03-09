using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;

namespace CineMagicData.Models
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

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MovieContext>
    {
        public MovieContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CineMagicApi")) // adjust the path
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<MovieContext>();
            var connectionString = configuration.GetConnectionString("default");
            builder.UseMySQL(connectionString);
            return new MovieContext(configuration);
        }
    }
}
