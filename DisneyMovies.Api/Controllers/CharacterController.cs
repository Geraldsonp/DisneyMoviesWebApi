using DisneyMovies.Api.Common;
using DisneyMovies.Api.Filters;
using DisneyMovies.Api.Models.CharacterModels;
using DisneyMovies.Application.Services.CharacterService;
using DisneyMovies.Application.Services.MediaService;
using DisneyMovies.Core.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DisneyMovies.Api.Controllers;

[ApiController]
[Authorize]
[Route("characters")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;
    private readonly IMapper _mapster;
    private readonly IMediaService _mediaService;

    public CharacterController(ICharacterService characterService, IMapper mapster, IMediaService mediaService)
    {
        _characterService = characterService;

        _mapster = mapster;
        _mediaService = mediaService;
    }

    // GET
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<CharacterResponse>))]
    public IActionResult GetAllCharacters([FromQuery] CharacterParams @params)
    {
        if (@params.Age != 0 || @params.Movies != 0 || @params.Name is not null || @params.Weight != 0)
        {
            var filteredCharacters =
                _characterService.GetByParams(@params.Age, @params.Movies, @params.Name, @params.Weight);
            return Ok(_mapster.Map<IEnumerable<CharacterResponse>>(filteredCharacters));
        }

        var characters = _characterService.GetAll();
        return Ok(_mapster.Map<IEnumerable<CharacterResponse>>(characters));
    }

    //GetById
    [HttpGet("{id:int}")]
    [ServiceFilter(typeof(MediaExistenceFilter))]
    [ProducesResponseType(200, Type = typeof(CharacterDetailsResponse))]
    [ProducesResponseType(404)]
    public IActionResult GetCharacter(int id)
    {
        var character = _characterService.Get(id);

        return Ok(_mapster.Map<CharacterDetailsResponse>(character));
    }

    //Post
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(CharacterDetailsResponse))]
    public IActionResult CreateCharacter(CreateCharacterRequest characterRequest)
    {
        var character = _characterService.Create(_mapster.Map<Character>(characterRequest));
        return CreatedAtAction(nameof(GetCharacter), new { character.Id }, character);
    }

    [HttpPut("{id:int}/movies")]
    [ServiceFilter(typeof(MediaExistenceFilter))]
    [ProducesResponseType(200, Type = typeof(CharacterDetailsResponse))]
    [ProducesResponseType(404)]
    public IActionResult AddMediaToCharacter(int id, AddMediaRequest addMediaRequest)
    {
        var mediaExist = _mediaService.MediaExist(addMediaRequest.MediaId);
        if (mediaExist)
        {
            var updatedCharacter = _characterService.UpdateMedias(addMediaRequest.MediaId, id);

            return Ok(_mapster.Map<CharacterDetailsResponse>(updatedCharacter));
        }
        else
        {
            return NotFound("Character Or Movie Not Found");
        }
    }


    //Delete
    [HttpDelete("{id:int}/movies/{movieId:int}")]
    [ServiceFilter(typeof(MediaExistenceFilter))]
    [ProducesResponseType(200, Type = typeof(CharacterDetailsResponse))]
    [ProducesResponseType(404)]
    public IActionResult DeleteMediaFromCharacter(int id, int movieId)
    {
        var mediaExist = _mediaService.MediaExist(movieId);
        if (mediaExist)
        {
            var updatedCharacter = _characterService.UpdateMedias(movieId, id);

            return Ok(_mapster.Map<CharacterDetailsResponse>(updatedCharacter));
        }
        else
        {
            return NotFound("Character Or Movie Not Found");
        }
    }

    [HttpDelete("{id:int}")]
    [ServiceFilter(typeof(MediaExistenceFilter))]
    [ProducesResponseType(200, Type = typeof(CharacterDetailsResponse))]
    [ProducesResponseType(404)]
    public IActionResult DeleteCharacter(int id)
    {
        _characterService.Delete(id);
        return Ok();
    }

    //Update
    [HttpPut("{id:int}")]
    [ServiceFilter(typeof(MediaExistenceFilter))]
    [ProducesResponseType(200, Type = typeof(CharacterDetailsResponse))]
    [ProducesResponseType(404)]
    public IActionResult UpdateCharacter(int id, CreateCharacterRequest character)
    {
        var characterModel = _mapster.Map<Character>(character);
        var characterResponse = _characterService.Update(id, characterModel);

        return Ok(characterResponse);
    }
}