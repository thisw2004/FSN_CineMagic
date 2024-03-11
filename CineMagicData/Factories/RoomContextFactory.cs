using CineMagicData.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CineMagicData.Factories;

public class RoomContextFactory : IDesignTimeDbContextFactory<Contexts.RoomContext>
{
    
    public Contexts.RoomContext CreateDbContext(string[] args)
    {
        // Up to the solution directory
        var solutionPath = Path.Combine(Directory.GetCurrentDirectory(), "..");

        // Navigate to the CineMagicApi project directory
        var projectPath = Path.Combine(solutionPath, "CineMagicApi");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(projectPath)
            .AddJsonFile("appsettings.json")
            .Build();

        // var connectionString = configuration.GetConnectionString("DefaultConnection");

        return new Contexts.RoomContext(configuration);
    }
}