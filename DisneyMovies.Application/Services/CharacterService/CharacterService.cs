using DisneyMovies.Core.Contracts.Persistence;
using DisneyMovies.Core.Entities;
using DisneyMovies.Core.Exceptions;
using MapsterMapper;

namespace DisneyMovies.Application.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly IUnitOfWork _unitOfWork;
   

    public CharacterService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
       
    }

    public IEnumerable<Character> GetByParams(int age, int movieId, string name, double weight)
    {
        var characters = _unitOfWork.CharacterRepository.GetRangeByCondition(c => c.Name.Contains(name)
            || c.Age == age || c.Weight == weight || c.CharactersMedias.Any(m => m.MediaId == movieId));

        return characters;
    }

    public IEnumerable<Character> GetAll()
    {
        var characters = _unitOfWork.CharacterRepository.GetAll();
        return characters;
    }

    public Character Get(int id)
    {
        var character = _unitOfWork.CharacterRepository.GetByCondition(character => character.Id == id);
        if (character is null)
        {
            throw new EntityNotFoundException(new Character(), id);
        }

        return character;
    }

    public Character Create(Character character)
    {
        _unitOfWork.CharacterRepository.Add(character);
        _unitOfWork.Save();
        return character;
    }

    public void Delete(int id)
    {
        var character = Get(id);
        _unitOfWork.CharacterRepository.Delete(character);
        _unitOfWork.Save();
    }

    public Character Update(int id, Character character)
    {
        _unitOfWork.CharacterRepository.Update(character);
        _unitOfWork.Save();
        return character;
    }
}