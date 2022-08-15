using DisneyMovies.Core.Entities;

namespace DisneyMovies.Core.Contracts.Persistence;

public interface IUserRepository : IRepository<User>
{
    bool CheckEmailAlreadyUsed(string email);
}