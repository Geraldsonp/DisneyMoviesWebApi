using DisneyMovies.Core.Contracts.Persistence;
using DisneyMovies.Core.Entities;
using DisneyMovies.Core.Exceptions;
using Mapster;

namespace DisneyMovies.Application.Services.MediaService;

public class MediaService : IMediaService
{
    private readonly IUnitOfWork _unitOfWork;

    public MediaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Media> GetAll()
    {
        return _unitOfWork.MediaRepository.GetAll();
    }

    public IEnumerable<Media> GetByParams(string name, int? genreId, string order = "asc")
    {
        if (order == "desc")
        {
            return _unitOfWork.MediaRepository.GetRangeByCondition(m => m.Title.Contains(name))
                .OrderByDescending(m => m.Title);
        }

        return _unitOfWork.MediaRepository.GetRangeByCondition(m => m.Title.Contains(name))
            .OrderBy(m => m.Title);
    }

    public Media Get(int id)
    {
        var media = _unitOfWork.MediaRepository.GetByCondition(m => m.Id == id);
        if (media is null)
        {
            throw new EntityNotFoundException(media, id);
        }

        return media;
    }

    public Media Create(Media media)
    {
       
        _unitOfWork.MediaRepository.Add(media);
        _unitOfWork.Save();
        return media;
    }

    public Media Update(Media updatedMedia, int id)
    {
        var media = Get(id);

        media.Title = updatedMedia.Title;
        media.ImgUrl = updatedMedia.ImgUrl;
        media.DurationInMinutes = updatedMedia.DurationInMinutes;
        media.CreationDate = updatedMedia.CreationDate;
        media.Type = updatedMedia.Type;
        media.Rating = updatedMedia.Rating;

        _unitOfWork.Save();

        return media;
    }

    public void Delete(int id)
    {
        var media = Get(id);
        _unitOfWork.MediaRepository.Delete(media);
        _unitOfWork.Save();
    }
}