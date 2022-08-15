using System.Linq.Expressions;
using DisneyMovies.Core.Entities;

namespace DisneyMovies.Core.Contracts.Persistence;

public interface IRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll();
    T GetByCondition(Expression<Func<T, bool>> expression);
    IEnumerable<T> GetRangeByCondition(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    
}