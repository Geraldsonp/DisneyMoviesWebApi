using System.Text.Json.Serialization;
using DisneyMovies.Application.Common.Mapping;

namespace DisneyMovies.Api;

public static class DependencyInjection
{
    public static void AddApiDependencies(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}