using System.Linq.Expressions;
using DisneyMovies.Core.Contracts.Persistence;
using DisneyMovies.Core.Entities;

namespace DisneyMovies.Infrastructure.Persistence.Repositories;

public abstract class RepositoryBase<T> : IRepository<T>  where T : BaseEntity 
{
    private readonly DisneyMoviesDbContext _context;

    public RepositoryBase(DisneyMoviesDbContext context)
    {
        _context = context;
    }
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetByCondition(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression).SingleOrDefault();
    }

    public IEnumerable<T> GetRangeByCondition(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression).ToList();
    }

    public void Add(T Entity)
    {
        _context.Set<T>().Add(Entity);
    }

    public void Delete(T Entity)
    {
        _context.Set<T>().Remove(Entity);
    }

    public void Update(T Entity)
    {
        _context.Set<T>().Update(Entity);
    }
}