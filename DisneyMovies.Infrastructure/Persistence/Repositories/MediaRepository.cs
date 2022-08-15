using DisneyMovies.Core.Contracts.Persistence;
using DisneyMovies.Core.Entities;

namespace DisneyMovies.Infrastructure.Persistence.Repositories;

public class MediaRepository : RepositoryBase<Media>, IMediaRepository
{
    public MediaRepository(DisneyMoviesDbContext context) : base(context)
    {
    }
}