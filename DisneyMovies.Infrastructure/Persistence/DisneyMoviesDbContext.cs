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
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new MediaConfiguration());
        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        
        
        modelBuilder.Entity("CharacterMedia").HasData(
            new { CharactersId = 5, MediasId = 5 },
            new { CharactersId = 1, MediasId = 5 },
            new { CharactersId = 2, MediasId = 5 },
            new { CharactersId = 3, MediasId = 5 }
        );
        modelBuilder.Entity("GenreMedia").HasData(
            new { GenresId = 9, MediasId = 5 },
            new { GenresId = 8, MediasId = 5 }
        );
        
    }

    public DbSet<User>? Users { get; set; }
    public DbSet<Character>? Characters { get; set; }
    public DbSet<Genre>? Genres { get; set; }
    public DbSet<Media>? Medias { get; set; }
    
}