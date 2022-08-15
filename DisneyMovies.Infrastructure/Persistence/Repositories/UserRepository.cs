using DisneyMovies.Core.Contracts.Persistence;
using DisneyMovies.Core.Entities;

namespace DisneyMovies.Infrastructure.Persistence.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    private readonly DisneyMoviesDbContext _context;

    public UserRepository(DisneyMoviesDbContext context):base(context)
    {
        _context = context;
    }

    public bool CheckEmailAlreadyUsed(string email)
    {
        return _context.Users
            .Any(u => u.Email == email);
    }
}