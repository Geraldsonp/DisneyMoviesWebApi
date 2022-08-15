using DisneyMovies.Core.Contracts.Persistence;
using DisneyMovies.Core.Entities;

namespace DisneyMovies.Infrastructure.Persistence.Repositories;

public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
{
    public CharacterRepository(DisneyMoviesDbContext context) : base(context)
    {
    }
}