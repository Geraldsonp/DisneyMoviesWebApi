using DisneyMovies.Api.Common;
using DisneyMovies.Api.Filters;
using DisneyMovies.Api.Models.MediaModels;
using DisneyMovies.Application.Services.MediaService;
using DisneyMovies.Core.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DisneyMovies.Api.Controllers;

[Authorize]
[ApiController, Route("movies")]
public class MediaController : Controller
{
    private readonly IMediaService _mediaService;
    private readonly IMapper _mapster;

    public MediaController(IMediaService mediaService, IMapper mapster)
    {
        _mediaService = mediaService;
        _mapster = mapster;
    }

    // GET
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<MediaResponse>))]
    public IActionResult GetAllMedia([FromQuery] MediaParams mediaParams)
    {
        if (mediaParams.Name is not null || mediaParams.Order is not null || mediaParams.GenreId is not null)
        {
            var mediasByParams =
                _mediaService.GetByParams(name: mediaParams.Name!, genreId: mediaParams.GenreId,
                    order: mediaParams.Order!);
            return Ok(_mapster.Map<IEnumerable<MediaResponse>>(mediasByParams));
        }

        var medias = _mediaService.GetAll();
        return Ok(_mapster.Map<IEnumerable<MediaResponse>>(medias));
    }

    // GET
    [HttpGet("{id:int}")]
    [ServiceFilter(typeof(MediaExistenceFilter))]
    [ProducesResponseType(200, Type = typeof(MediaDetailsResponse))]
    [ProducesResponseType(404)]
    public IActionResult GetMedia(int id)
    {
        var media = _mediaService.Get(id);

        return Ok(_mapster.Map<MediaDetailsResponse>(media));
    }

    //Post
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(MediaDetailsResponse))]
    public IActionResult CreateMedia(MediaCreateOrUpdateRequest createOrUpdateRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.ValidationState);
        }

        var mediaCreated = _mediaService.Create(_mapster.Map<Media>(createOrUpdateRequest));
        return CreatedAtAction(nameof(GetMedia), routeValues: new { mediaCreated.Id }, mediaCreated);
    }

    //PUT
    [HttpPut("{id:int}")]
    [ServiceFilter(typeof(MediaExistenceFilter))]
    [ProducesResponseType(200, Type = typeof(MediaDetailsResponse))]
    [ProducesResponseType(404)]
    public IActionResult UpdateMedia(MediaCreateOrUpdateRequest updateOrUpdateRequest, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values);
        }

        var mediaToUpdate = _mapster.Map<Media>(updateOrUpdateRequest);
        var mediaUpdated = _mediaService.Update(mediaToUpdate, id: id);

        return Ok(mediaUpdated);
    }

    //Delete
    [HttpDelete("{id:int}")]
    [ServiceFilter(typeof(MediaExistenceFilter))]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteMedia(int id)
    {
        _mediaService.Delete(id);
        return NoContent();
    }
}