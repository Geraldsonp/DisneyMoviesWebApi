using DisneyMovies.Core.Entities;

namespace DisneyMovies.Application.Services.MediaService;

public interface IMediaService
{
    IEnumerable<Media> GetAll();
    IEnumerable<Media> GetByParams(string name, int? genreId, string order = "asc");
    Media Get(int id);
    Media Create(Media createRequest);
    Media Update(Media updatedMedia, int id);
    void Delete(int id);
    bool MediaExist(int movieId);
}