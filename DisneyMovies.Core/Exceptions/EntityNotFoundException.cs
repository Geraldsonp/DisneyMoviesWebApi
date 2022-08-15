using DisneyMovies.Core.Entities;

namespace DisneyMovies.Core.Exceptions;

public class EntityNotFoundException : NotFountException
{
    public EntityNotFoundException(BaseEntity entity, int entityId) : base($"The {entity.GetType()} with the id: {entityId} does not exist in the database")
    {
    }
}