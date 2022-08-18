using DisneyMovies.Api.Models.CharacterModels;
using DisneyMovies.Api.Models.MediaModels;
using DisneyMovies.Application.Services.CharacterService.Common;
using DisneyMovies.Core.Entities;
using Mapster;
using TinyHelpers.Extensions;

namespace DisneyMovies.Api.Mapping;

public class CharacterMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Character, CharacterDetailsResponse>()
            .Map(dest => dest.Medias, src =>
                (src.Medias.Adapt<IEnumerable<MediaDetailsResponse>>()))
           ;
    }
}