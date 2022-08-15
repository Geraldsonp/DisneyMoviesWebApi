using DisneyMovies.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisneyMovies.Infrastructure.Persistence.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasData(
            new Genre { Id = 1, ImgUrl = "", Name = "Action" },
            new Genre { Id = 2, ImgUrl = "", Name = "Comedy" },
            new Genre { Id = 3, ImgUrl = "", Name = "Drama" },
            new Genre { Id = 4, ImgUrl = "", Name = "Fantasy" },
            new Genre { Id = 5, ImgUrl = "", Name = "Christmas" },
            new Genre { Id = 6, ImgUrl = "", Name = "Mystery" },
            new Genre { Id = 7, ImgUrl = "", Name = "Romance" },
            new Genre { Id = 8, ImgUrl = "", Name = "Animation" },
            new Genre { Id = 9, ImgUrl = "", Name = "Family" }
            );
    }
}