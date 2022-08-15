using DisneyMovies.Core.Entities;
using DisneyMovies.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisneyMovies.Infrastructure.Persistence.Configurations;

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.HasData(new Media
        {
            Id = 5,
            Title = "Kim Possible",
            CreationDate = new DateTime(year: 2002, month: 01, day: 01),
            Rating = 3,
            ImgUrl = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/qsDNX8DPwWydDn9oUIhe1WcTuUH.jpg",
            DurationInMinutes = 23,
            Type = MediaType.Serie,
        });
    }
}