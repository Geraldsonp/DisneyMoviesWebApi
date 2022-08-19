using DisneyMovies.Application.Authentication;
using DisneyMovies.Application.Common.Interfaces;
using DisneyMovies.Application.Services.CharacterService;
using DisneyMovies.Application.Services.MediaService;
using DisneyMovies.Core.Contracts.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace DisneyMovies.Application;

public static class ApplicationDependencies 
{
    public static void AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ICharacterService, CharacterService>();
        services.AddScoped<IMediaService, MediaService>();
        


    }
}