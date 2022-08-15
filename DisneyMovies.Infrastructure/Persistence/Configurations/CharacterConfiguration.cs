using DisneyMovies.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisneyMovies.Infrastructure.Persistence.Configurations;

public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.HasData(
            new Character() { Id = 5, Name = "Kimberly Ann Possible", Age = 14, History =
                    "is a high school student and freelance hero/vigilante. She is unusual in this in that she not only lacks a secret identity, but also remains on good terms with various law enforcement, government, and military agencies. ",
                ImgUrl = "https://static.wikia.nocookie.net/kimpossible/images/4/49/Kim_Possible_Mugshot.png/revision/latest?cb=20150728134300",
                Weight = 50
            },
            new Character()
            {
                Id = 1, Name = "Ron Stoppable", Age = 15, Weight = 55,
                ImgUrl = "https://static.wikia.nocookie.net/kimpossible/images/b/b2/Ron_Stoppable_Mugshot.png/revision/latest?cb=20120416162613",
                History = "Ronald Stoppable has been Kim Possible's best friend since Pre-K, her next door neighbor, and finally boyfriend, mainly serving as her sidekick during missions."
            },
            new Character()
            {
                Id = 2, Age = 14, Name = "Bonnie RockWaller", Weight = 60,
                ImgUrl = "https://static.wikia.nocookie.net/kimpossible/images/9/97/Bonnie_Mugshot.png/revision/latest?cb=20120420210125",
                History = "Bonnie Rockwaller is Kim Possible's Middleton High School classmate, fellow cheerleader, and her archrival since at least middle school."
            },
            new Character()
            {
                Id = 3, Age = 35, Name = "Drew Lipsky", Weight = 80,
                ImgUrl = "https://static.wikia.nocookie.net/kimpossible/images/d/d3/Dr.Drakken.png/revision/latest/scale-to-width-down/200?cb=20200208094132",
                History = "Drew Theodore P. Lipsky, alias Dr. Drakken, is a genius robotics inventor and engineer, considered by Kim Possible as her arch-nemesis. A self-proclaimed mad scientist, Drakken dreamed of world domination, but was constantly thwarted by the efforts of Team Possible. Voiced by John DiMaggio, he is the show's main antagonist."
            });
    }
}