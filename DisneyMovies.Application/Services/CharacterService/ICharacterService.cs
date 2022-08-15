using DisneyMovies.Core.Entities;

namespace DisneyMovies.Application.Services.CharacterService;

public interface ICharacterService
{
    IEnumerable<Character> GetByParams(int age, int movieId, string name, double weight);
    IEnumerable<Character> GetAll();
    Character Get(int id);
    Character Create(Character character);
    void Delete(int id);
    Character Update(int id, Character character);
}