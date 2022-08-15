using DisneyMovies.Api.Models.CharacterModels;
using DisneyMovies.Api.Models.MediaModels;
using DisneyMovies.Core.Entities;
using Mapster;

namespace DisneyMovies.Api.Mapping;

public class MediaMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Media, MediaDetailsResponse>()
            .Map(dest => dest.Genres, src =>
                (src.GenreMedias.Select(m => m.Genre)))
            .Map(dest => dest.Characters,
                src => src.CharacterMedias.Select(c => c.Character).Adapt<IEnumerable<CharacterDetailsResponse>>())
            .Ignore();

    }
}