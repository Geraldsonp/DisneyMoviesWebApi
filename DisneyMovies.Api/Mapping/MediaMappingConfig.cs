using DisneyMovies.Api.Models.CharacterModels;
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
            .Map(src => src.GenresId.Select(x => new Genre(){Id = x}), src => src.Genres)
            .Map(src => src.CharactersId.Select(x => new Character(){Id = x}), src => src.Characters);
        
        //Todo: test This
    }
}