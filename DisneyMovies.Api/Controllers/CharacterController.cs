using DisneyMovies.Api.Common;
using DisneyMovies.Api.Models.CharacterModels;
using DisneyMovies.Application.Services.CharacterService;
using DisneyMovies.Application.Services.CharacterService.Common;
using DisneyMovies.Core.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DisneyMovies.Api.Controllers;

[ApiController]
[Authorize]
[Route("characters")]
public class CharacterController : Controller
{
    private readonly ICharacterService _characterService;
    private readonly IMapper _mapster;

    public CharacterController(ICharacterService characterService, IMapper mapster)
    {
        _characterService = characterService;
        _mapster = mapster;
    }

    // GET
    [HttpGet]
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
    public IActionResult GetCharacter(int id)
    {
        var character = _characterService.Get(id);
        
        return Ok(_mapster.Map<CharacterDetailsResponse>(character));
    }

    //Post
    [HttpPost]
    public IActionResult CreateCharacter(CreateCharacterRequest characterRequest)
    {
        var character = _characterService.Create(_mapster.Map<Character>(characterRequest));
        return CreatedAtAction(nameof(GetCharacter), new { character.Id }, character);
    }

    //Delete
    [HttpDelete("{id:int}")]
    public IActionResult DeleteCharacter(int id)
    {
        _characterService.Delete(id);
        return Ok();
    }

    //Update
    [HttpPut("{id:int}")]
    public IActionResult UpdateCharacter(int id, Character character)
    {
        var characterResponse = _characterService.Update(id, character);
        return Ok(characterResponse);
    }
}