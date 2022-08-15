namespace DisneyMovies.Core.Contracts.Persistence;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    ICharacterRepository CharacterRepository { get; }
    IMediaRepository MediaRepository { get; }
    void Save();
}