using System.Collections.Generic;
using DisneyMovies.Api.Common;
using DisneyMovies.Api.Controllers;
using DisneyMovies.Api.Mapping;
using DisneyMovies.Api.Models.CharacterModels;
using DisneyMovies.Api.Models.MediaModels;
using DisneyMovies.Application.Services.CharacterService;
using DisneyMovies.Application.Services.MediaService;
using DisneyMovies.Core.Entities;
using FluentAssertions;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Test.MockData;
using Xunit;

namespace WebApi.Test;

public class CharacterControllerTest
{
    private CharacterParams? _parameters;
    private CharacterController _SUT;
    private IMapper _mapper;
    private Mock<ICharacterService> _characterService;
    private Mock<IMediaService> _mediaService;

    private void Setup()
    {
        var config = new TypeAdapterConfig();
        config.NewConfig<Character, CharacterDetailsResponse>()
            .Map(dest => dest.Medias, src =>
                (src.Medias.Adapt<IEnumerable<MediaDetailsResponse>>()))
            ;
        _parameters = new CharacterParams()
        {
            Name = "",
            Age = 0,
            Movies = 0,
            Weight = 0
        };
        
        
        _mapper = new Mapper(config);
        _characterService = new Mock<ICharacterService>();
        _mediaService = new Mock<IMediaService>();
    }

    [Fact]
    public void GetAllCharacter_Should_Return_FilteredList()
    {
        //Arrange
        Setup();
        _parameters.Name = "paradigm";
        _characterService
            .Setup(x => x.GetByParams(_parameters.Age, _parameters.Movies, _parameters.Name, _parameters.Weight))
            .Returns(CharactersMoq.GetCharacters);
        _SUT = new CharacterController(_characterService.Object, _mapper, _mediaService.Object);
        //Act
        var result = (OkObjectResult)_SUT.GetAllCharacters(_parameters);

        //Assert
        result.StatusCode.Should().Be(200);
    }
}