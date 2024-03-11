using CineMagicApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CineMagicApi;

public partial class SampleDBContext: DbContext
{
    public SampleDBContext(DbContextOptions<SampleDBContext> options) : base(options)
    {
        
    }

    public virtual DbSet<Movie> Movie { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(k => k.MovieId);
        });
    }

}