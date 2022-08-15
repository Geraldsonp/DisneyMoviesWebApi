using DisneyMovies.Application.Authentication.Common;
using DisneyMovies.Application.Common.Interfaces;
using DisneyMovies.Application.DataTransferObjects;
using DisneyMovies.Application.Services;
using DisneyMovies.Core.Contracts.Persistence;
using DisneyMovies.Core.Entities;
using Mapster;

namespace DisneyMovies.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public AuthenticationService(IUnitOfWork unitOfWork, IJwtTokenGenerator tokenGenerator)
    {
        _unitOfWork = unitOfWork;
        _tokenGenerator = tokenGenerator;
    }
    public AuthenticationResult Register(RegisterRequest request)
    {
        var emailAlreadyInUse = _unitOfWork.UserRepository.CheckEmailAlreadyUsed(request.Email);
        
        if (!emailAlreadyInUse)
        {
            var user = request.Adapt<User>();
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Save();
            var token = _tokenGenerator.GenerateToken(user.Id, user.Name, user.UserName);
            return new AuthenticationResult(){IsSuccess = true, Token = token};
        }

        return new AuthenticationResult(){IsSuccess = false, Token = null};
    }

    public AuthenticationResult LogIn(LogInRequest request)
    {
        var user = _unitOfWork.UserRepository?.GetByCondition(u =>
            u.UserName == request.UserName && u.Password == request.Password);
        if (user is null)
        {
            return new AuthenticationResult()
            {
                IsSuccess = false,
                Token = "User With Given UserName or Password Does not exist"
            };
        }
        var token = _tokenGenerator.GenerateToken(user.Id, user.Name, user.UserName);
        return new AuthenticationResult() { IsSuccess = true, Token = token };
    }
}