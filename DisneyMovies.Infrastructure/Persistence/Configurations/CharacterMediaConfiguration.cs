using DisneyMovies.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisneyMovies.Infrastructure.Persistence.Configurations;

public class CharacterMediaConfiguration : IEntityTypeConfiguration<CharacterMedia>
{
    public void Configure(EntityTypeBuilder<CharacterMedia> builder)
    {
        builder.HasKey(mc => new { mc.CharacterId, mc.MediaId });
        builder.HasOne(mc => mc.Character)
            .WithMany(c => c.CharactersMedias)
            .HasForeignKey(mc => mc.CharacterId);
        builder.HasOne(mc => mc.Media)
            .WithMany(c => c.CharacterMedias)
            .HasForeignKey(mc => mc.MediaId);

        builder.HasData(
            new CharacterMedia { CharacterId = 5, MediaId = 5 },
            new CharacterMedia { CharacterId = 1, MediaId = 5 },
            new CharacterMedia { CharacterId = 2, MediaId = 5 },
            new CharacterMedia { CharacterId = 3, MediaId = 5 }
        );
    }
}