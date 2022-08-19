using DisneyMovies.Api.Models.CharacterModels;
using DisneyMovies.Api.Models.GenreModels;
using DisneyMovies.Api.Models.MediaModels;
using DisneyMovies.Core.Entities;
using Mapster;

namespace DisneyMovies.Api.Mapping;

public class MediaMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Media, MediaDetailsResponse>()
            .Map(dest => dest.Genres, src =>
                (src.Genres))
            .Map(dest => dest.Characters,
                src => src.Characters.Adapt<IEnumerable<CharacterDetailsResponse>>())
            .Ignore();

        config.NewConfig<Media, MediaCreateOrUpdateRequest>()
            .Map(src => src.Genres, src => src.Genres.Adapt<GenreResponse>())
            .Map(src => src.Characters, src => src.Characters.Adapt<CharacterResponse>());
        
    }
}