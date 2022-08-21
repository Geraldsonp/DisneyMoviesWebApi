using DisneyMovies.Api.Controllers;
using DisneyMovies.Application.Services.CharacterService;
using DisneyMovies.Application.Services.MediaService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DisneyMovies.Api.Filters;

public class MediaExistenceFilter : IActionFilter
{
    private readonly IMediaService _mediaService;
    private readonly ICharacterService _characterService;

    public MediaExistenceFilter(IMediaService mediaService, ICharacterService characterService)
    {
        _mediaService = mediaService;
        _characterService = characterService;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var controller = context.Controller;
        if (controller.GetType() == (typeof(MediaController)))
        {
            var mediaId = context.RouteData.Values["Id"];
            var mediaExist = _mediaService.MediaExist(Int32.Parse(mediaId.ToString()));
            if (!mediaExist)
            {
                context.Result = new NotFoundObjectResult($"Media with id {mediaId} Does not exist");
            }
        }
        else
        {
            var characterId = context.RouteData.Values["Id"];
            var characterExist = _characterService.CharacterExist(Int32.Parse(characterId.ToString()));
            if (!characterExist)
            {
                context.Result = new NotFoundObjectResult($"with id {characterId} Does not exist");
            }
        }

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}