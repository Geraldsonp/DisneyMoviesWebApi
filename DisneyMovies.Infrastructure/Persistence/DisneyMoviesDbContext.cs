using DisneyMovies.Core.Entities;
using DisneyMovies.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DisneyMovies.Infrastructure.Persistence;

public class DisneyMoviesDbContext : DbContext
{
    public DisneyMoviesDbContext(DbContextOptions<DisneyMoviesDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<GenreMedia>(new GenreMediaConfiguration());
        modelBuilder.ApplyConfiguration<Genre>(new GenreConfiguration());
        modelBuilder.ApplyConfiguration<Media>(new MediaConfiguration());
        modelBuilder.ApplyConfiguration<Character>(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration<CharacterMedia>(new CharacterMediaConfiguration());
        modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
    }

    public DbSet<User>? Users { get; set; }
    public DbSet<Character>? Characters { get; set; }
    public DbSet<Genre>? Genres { get; set; }
    public DbSet<Media>? Medias { get; set; }
    
}