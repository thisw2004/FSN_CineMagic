using CineMagicData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CineMagicData.Factories;

public class OrderContextFactory : IDesignTimeDbContextFactory<Contexts.OrderContext>
{
    public Contexts.OrderContext CreateDbContext(string[] args)
    {
         //Getting api directory   
        var solutionPath = Path.Combine(Directory.GetCurrentDirectory(), "..");

        var projectPath = Path.Combine(solutionPath, "CineMagicApi");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(projectPath)
            .AddJsonFile("appsettings.json")
            .Build();

        //Returning to context
        return new Contexts.OrderContext(configuration);
    }
}