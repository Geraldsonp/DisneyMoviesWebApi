using DisneyMovies.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisneyMovies.Infrastructure.Persistence.Configurations;

public class GenreMediaConfiguration : IEntityTypeConfiguration<GenreMedia>
{
    public void Configure(EntityTypeBuilder<GenreMedia> builder)
    {
        builder.HasKey(gm => new {  gm.GenreId, gm.MediaId });
        builder.HasOne(gm => gm.Media)
            .WithMany(m => m.GenreMedias)
            .HasForeignKey(media => media.MediaId);
        builder.HasOne(gm => gm.Genre)
            .WithMany(genre => genre.GenreMedias)
            .HasForeignKey(genre => genre.GenreId);

        builder.HasData(
            new GenreMedia() { GenreId = 2, MediaId = 5 },
            new GenreMedia() { GenreId = 8, MediaId = 5 }
        );
    }
}