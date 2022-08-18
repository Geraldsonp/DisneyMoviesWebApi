using Castle.Core.Configuration;
using DisneyMovies.Application.Authentication;
using DisneyMovies.Application.Common.Interfaces;
using DisneyMovies.Application.Services.CharacterService;
using DisneyMovies.Application.Services.MediaService;
using DisneyMovies.Core.Contracts.Persistence;
using DisneyMovies.Infrastructure.Authentication;
using DisneyMovies.Infrastructure.Persistence;
using DisneyMovies.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace DisneyMovies.Infrastructure;

public static class InfrastructureDependencies 
{
    public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DisneyMoviesDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("Default"));
            options.UseLazyLoadingProxies();
        });
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ICharacterService, CharacterService>();
        services.AddScoped<IMediaService, MediaService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    }
}