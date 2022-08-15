using DisneyMovies.Application.Authentication;
using DisneyMovies.Application.Common.Interfaces;
using DisneyMovies.Application.Services.CharacterService;
using DisneyMovies.Application.Services.MediaService;
using DisneyMovies.Core.Contracts.Persistence;
using DisneyMovies.Infrastructure.Authentication;
using DisneyMovies.Infrastructure.Persistence;
using DisneyMovies.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DisneyMovies.Infrastructure;

public static class InfrastructureDependencies 
{
    public static void AddInfrastructureDependencies(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DisneyMoviesDbContext>(options =>
        {
            options.UseSqlite(connectionString);
            options.UseLazyLoadingProxies();
        });
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ICharacterService, CharacterService>();
        services.AddScoped<IMediaService, MediaService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    }
}