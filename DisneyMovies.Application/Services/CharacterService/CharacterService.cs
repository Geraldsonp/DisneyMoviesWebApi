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

    public IEnumerable<Character> GetByParams(int age, int movieId, string? name, double weight)
    {
        var characters = _unitOfWork.CharacterRepository.GetRangeByCondition(c => c.Name.Contains(name)
            || c.Age == age || c.Weight == weight || c.Medias.Any(m => m.Id == movieId));

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

    public Character Update(int id, Character characterToUpdate)
    {
        var character = _unitOfWork.CharacterRepository.GetByCondition(c => c.Id == id);
        characterToUpdate.Medias = character.Medias;
        _unitOfWork.CharacterRepository.Update(characterToUpdate);
        _unitOfWork.Save();
        return characterToUpdate;
    }

    public bool CharacterExist(int characterid)
    {
        var character = _unitOfWork.CharacterRepository.GetByCondition(c => c.Id == characterid);
        if (character is null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public Character UpdateMedias(int mediaId, int characterId)
    {
        var character = Get(characterId);
        var media = _unitOfWork.MediaRepository.GetByCondition(m => m.Id == mediaId);
        if (character.Medias!.Any(m => m.Id == mediaId))
        {
            character.Medias?.Remove(media);

            _unitOfWork.Save();
            return character;
        }

        character.Medias?.Add(media);

        _unitOfWork.Save();
        return character;
    }
}