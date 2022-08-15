using DisneyMovies.Core.Contracts.Persistence;

namespace DisneyMovies.Infrastructure.Persistence.Repositories;

public class UnitOfWork :IUnitOfWork
{
    private DisneyMoviesDbContext _context;
    private IUserRepository? _user;
    private ICharacterRepository? _character;
    private IMediaRepository? _mediaRepository;

    public UnitOfWork(DisneyMoviesDbContext context)
    {
        _context = context;
    }


    public IUserRepository UserRepository => _user ?? (_user = new UserRepository(_context));
    public ICharacterRepository CharacterRepository => _character ?? (_character = new CharacterRepository(_context));
    public IMediaRepository MediaRepository => _mediaRepository ?? (_mediaRepository = new MediaRepository(_context));
    public void Save()
    {
        _context.SaveChanges();
    }
}